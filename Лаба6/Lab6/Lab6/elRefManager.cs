// Title: Programmatically add references 

// Description: Programmatically add references to Visual Studio

// Version: 1.0

// Date: 03-09-2005 (mm-dd-yyyy)
// Author: Matteo Peluso
// Company: Euclid Labs s.r.l.
// 
// URL: http://www.euclidlabs.it/components

//
// Notes: This script is free. Visit official site for further details. 
//

// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS

// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT

// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS

// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE

// COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,

// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,

// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;

// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER

// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT

// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN

// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE

// POSSIBILITY OF SUCH DAMAGE. 

using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.Win32;
using VSLangProj;

namespace ProgrammaticallyAddReferences
{
	/// <summary>
	/// This class allows you to check if one or more references are included in the open projects
	/// This code must be intended 'AS IS' with no warranties, and confers no rights.
	/// </summary>
	public class elRefManager
	{
		[DllImport("ole32.dll")]        
		private static extern int GetRunningObjectTable(int reserved, out UCOMIRunningObjectTable prot);    
    
		[DllImport("ole32.dll")]        
		private static extern int CreateBindCtx(int reserved, out UCOMIBindCtx ppbc);

		public elRefManager()
		{
		}

		/// <summary>
		/// Check if the needed references are found in the currently open projects.
		/// If it doesn't find it, it will try to add it.
		/// </summary>
		/// <param name="lookfor">
		/// Filter for selecting a subset of the open projects. Only projects that contains
		/// the specified references will be involved in this check.
		/// </param>
		/// <param name="toadd">Name of the references that must be added</param>
		/// <returns>
		/// Returns 0 if no errors. A negative value means an error with the parameters.
		/// A positive value means that at least one reference could not be found.
		/// </returns>
		internal static int CheckReferences(string[] lookfor, string[] toadd)
		{
			DTE dte;	
			Array activeProjects =null;
			int ec=0, missing=0;

			// Get references to the available instances of msdev
			ArrayList msdev = GetMSDEVFromGIT();

			if (msdev==null)
				return -1;

			// loop through all of them
			for (int i=0; i<msdev.Count; i++)
			{
				// cast to the right object
				dte=(DTE) msdev[i];
				try
				{
					// try to get a reference to the active projects
					activeProjects = (Array)dte.ActiveSolutionProjects;
				}
				catch (Exception)
				{
					continue;
				}

				// loop through all active projects
				for (int k=0; k<activeProjects.Length; k++)
				{
					// Check references in the project
					missing=CheckReferenceInProject((Project)activeProjects.GetValue(k), lookfor, toadd);
					if (missing<0)
						ec=-2;
					if (missing>0)
						ec=1;
				}
			}

			return ec;
		}

		/// <summary>
		/// Check if the needed references are found in the project.
		/// If it doesn't find it, it will try to add it.
		/// </summary>
		/// <param name="selectedProject">
		/// The project that should be considered in this check
		/// </param>
		/// <param name="lookfor">
		/// Filter for selecting a subset of the open projects. Only projects that contains
		/// the specified references will be involved in this check.
		/// </param>
		/// <param name="toadd">Name of the references that must be added</param>
		/// <returns>
		/// Returns 0 if no errors. A negative value means an error with the parameters.
		/// A positive value means the number of references that could not be found
		/// </returns>
		private static int CheckReferenceInProject(Project selectedProject,string[] lookfor, string[] toadd)
		{
			if (selectedProject==null)
				return -1;
			if (toadd==null)
				return 0;

			VSProject selectedVSProject=null;

			try
			{
				// Try to get a reference to the VSProject
				selectedVSProject = (VSProject)selectedProject.Object;
			}
			catch
			{
				return -1;
			}

			bool found=false;
			int missing=0;
			if (selectedVSProject != null)
			{
				// if there is a filter (lookfor parameter), check if the current VSProject is compliant
				if ((lookfor==null) || (lookfor.Length==0))
				{
					// No filter: go on with the check
					found=true;
				}
				else
				{
					// Check if the reference is found in the project
					for (int i=0; i<lookfor.Length; i++)
						if (!found)
							found=LookForReference(selectedVSProject.References, lookfor[i]);
				}


				if (found)
				{
					// loop through all the references that must be added
					for (int i=0; i<toadd.Length; i++)
					{
						// check if the reference is already present in the VSProject
						found=LookForReference(selectedVSProject.References, toadd[i]);
						if (!found)
						{
							// if the reference was not found, try to add it looking into the folders specified in the registry
							found=AddReferenceFromRegistry(selectedVSProject.References, toadd[i]);
						}
						if (!found)
						{
							// if the reference was not found in the folder specified in the registry,
							// look for it in the folder where the current references are found
							found=AddReference(selectedVSProject.References, toadd[i]);
						}

						// if it was not found, mark it in the missing variable
						if (!found)
							missing++;
					}
				}
			}
			return missing;
		}

		/// <summary>
		/// Try to add the reference s, looking in the same folders where other references are found
		/// </summary>
		/// <param name="references">Current project's references</param>
		/// <param name="s">Name of the reference that should be added</param>
		/// <returns>True if successful, false otherwise</returns>
		private static bool AddReference(References references, string s)
		{
			Reference reference;
			IEnumerator enumerator = references.GetEnumerator();
			string path;
			while (enumerator.MoveNext())
			{
				reference=(Reference) enumerator.Current;

				try
				{
					path=reference.Path;
					path=path.Replace(reference.Name, s);
					if (File.Exists(path))
					{
						references.Add(path);
						return true;
					}
				}
				catch {}
			}

			return false;
		}

		/// <summary>
		/// Look into the references to find if the target reference is present
		/// </summary>
		/// <param name="references">Current project's references</param>
		/// <param name="target">Name of the string that should be checked</param>
		/// <returns>true if the reference was find, false otherwise</returns>
		private static bool LookForReference(References references, string target)
		{
			Reference reference;
			IEnumerator enumerator = references.GetEnumerator();
			while (enumerator.MoveNext())
			{
				reference=(Reference) enumerator.Current;

				try
				{
					if (String.Compare(reference.Name,target, true)==0)
					{
						return true;
					}

				}
				catch (Exception)
				{
					return false;
				}
			}
			return false;
		}

		/// <summary>
		/// This function retrieves all the MSDev processes running on the machine.
		/// Thanks to Ed Dore [MSFT] for this code.
		/// You can see more about his article at 
		/// http://www.dotnet247.com/247reference/msgs/46/231613.aspx
		/// where I took this routine.
		/// </summary>
		/// <returns>An array containing all the instances of the msdev</returns>
		[STAThread]        
		private static ArrayList GetMSDEVFromGIT()        
		{            
			ArrayList tmp=new ArrayList();
			UCOMIRunningObjectTable prot;            
			UCOMIEnumMoniker pMonkEnum;            
			try            
			{                
				GetRunningObjectTable(0,out prot);                
				prot.EnumRunning(out pMonkEnum);                
				pMonkEnum.Reset(); // Churn through enumeration.                
				int fetched;                
				UCOMIMoniker []pmon = new UCOMIMoniker[1];                
				while(pMonkEnum.Next(1, pmon, out fetched) == 0)                 
				{                    
					UCOMIBindCtx pCtx;                    
					CreateBindCtx(0, out pCtx);                    
					string str;                    
					pmon[0].GetDisplayName(pCtx,null,out str);                
					if (str.IndexOf("VisualStudio.DTE")!=-1)
					{        
						object objReturnObject;        
						prot.GetObject(pmon[0],out objReturnObject);    
						tmp.Add(objReturnObject);        
					}        

				}    
			}    
			catch    
			{    
			}    
			return tmp;    
		}

		/// <summary>
		/// Try to add the reference s, looking into the folders specified in the registry
		/// </summary>
		/// <param name="references">Current project's references</param>
		/// <param name="s">Name of the reference that should be added</param>
		/// <returns>true if the reference was found and added, false otherwise</returns>
		private static bool AddReferenceFromRegistry(References references, string s)
		{
			bool found=false;
			RegistryKey baserk=null;

			// First of all check in the Local Machine section of the registry

			baserk=Registry.LocalMachine;
			if (!found) found=AddReferenceFromRegistry(references, s, baserk, @"SOFTWARE\Microsoft\.NETFramework\AssemblyFolders");
			if (!found)
			{
				// Get other paths...
				baserk=baserk.OpenSubKey(@"SOFTWARE\Microsoft\VisualStudio");
				string[] names = baserk.GetSubKeyNames();
				for (int i=0; i<names.Length; i++)
				{
					if (!found) found=AddReferenceFromRegistry(references, s, baserk, names[i] + @"\AssemblyFolders");
				}
			}

			// Then check in the Current User section of the registry

			baserk=Registry.CurrentUser;
			if (!found) found=AddReferenceFromRegistry(references, s, baserk, @"SOFTWARE\Microsoft\.NETFramework\AssemblyFolders");
			if (!found)
			{
				// Get other paths...
				baserk=baserk.OpenSubKey(@"SOFTWARE\Microsoft\VisualStudio");
				string[] names = baserk.GetSubKeyNames();
				for (int i=0; i<names.Length; i++)
				{
					if (!found) found=AddReferenceFromRegistry(references, s, baserk, names[i] + @"\AssemblyFolders");
				}
			}
			return found;
		}

		/// <summary>
		/// Try to add the reference s, looking into the folders specified in the registry key
		/// </summary>
		/// <param name="references">Current project's references</param>
		/// <param name="s">Name of the reference that should be added</param>
		/// <param name="source">Base registry key</param>
		/// <param name="rkname">Subkey name, containing the path where the reference should be looked for</param>
		/// <returns></returns>
		private static bool AddReferenceFromRegistry(References references, string s, RegistryKey source, string rkname)
		{
			string path;
			RegistryKey tmprk;

			if (source==null) return false;
			RegistryKey rk=source.OpenSubKey(rkname);
			if (rk==null) return false;

			string[] pathnames;
			pathnames=rk.GetSubKeyNames();
			if (pathnames==null) return false;

			for (int i=0; i<pathnames.Length; i++)
			{
				tmprk=rk.OpenSubKey(pathnames[i]);
				path=(string) tmprk.GetValue("", "");
	
				if ((path!="") && (File.Exists(path + s + ".dll")))
				{
					references.Add(path+s);
				}
			}
			return false;
		}
	}
}

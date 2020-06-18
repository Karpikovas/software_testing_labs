using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using EnvDTE80;
using EnvDTE;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using VSLangProj;
using Microsoft.Build;


namespace Lab6
{
    public partial class Form1 : Form
    {
        public List<SimpleTest> allTests;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            allTests = new List<SimpleTest>();
        }

        private void btnAddTestClick(object sender, EventArgs e)
        {
            var test = new SimpleTest(Namespace.Text, Class.Text, Method.Text, Params.Text, Expected.Text);
            allTests.Add(test);

            TreeNode testNode = new TreeNode("Тест №" + allTests.Count.ToString());

            testNode.Nodes.Add(new TreeNode("ns: " + test.Namespace));
            testNode.Nodes.Add(new TreeNode("cl: " + test.Class));
            testNode.Nodes.Add(new TreeNode("m: " + test.Method));
            testNode.Nodes.Add(new TreeNode("p: " + test.Params));
            testNode.Nodes.Add(new TreeNode("exp: " + test.Expected));

            tests.Nodes.Add(testNode);

        }

        private void btnRunTestsClick(object sender, EventArgs e)
        {
            results.Nodes.Clear();

            var testNum = 1;

            foreach (var test in allTests) {

                TreeNode testNode = new TreeNode("Test №" + testNum.ToString());

                
                try
                {

                    var myObj = Activator.CreateInstance(Type.GetType(test.Namespace + "." + test.Class));

                    MethodInfo m = myObj.GetType().GetMethod(test.Method);
                    MethodBase Mymethodbase = myObj.GetType().GetMethod(test.Method);
                    ParameterInfo[] Myarray = Mymethodbase.GetParameters();


                    string[] methodParams = test.Params.Split(';');
                    object[] methodParamsWithTypes = new object[methodParams.Length];

                    foreach (ParameterInfo Myparam in Myarray)
                    {
                        methodParamsWithTypes[Myparam.Position] = Convert.ChangeType(methodParams[Myparam.Position], Myparam.ParameterType);
                    }

                    var res = m.Invoke(myObj, test.Params.Length > 0 ? methodParamsWithTypes : null);

                    var expected = Convert.ChangeType(test.Expected, m.ReturnType);


                    if (res.Equals(expected))
                    {
                        testNode.ForeColor = Color.Green;
                        results.Nodes.Add(testNode);
                    }
                    else
                    {
                        testNode.ForeColor = Color.Red;
                        testNode.Nodes.Add(new TreeNode("msg: Полученные результаты не равны ожидаемым"));
                        testNode.Nodes.Add(new TreeNode("exp: " + test.Expected));
                        testNode.Nodes.Add(new TreeNode("res: " + res.ToString()));

                        results.Nodes.Add(testNode);
                    }
                }
                catch (Exception ex)
                {
                    testNode.ForeColor = Color.Red;


                    if (ex.InnerException != null)
                    {
                        testNode.Nodes.Add(new TreeNode("msg: " + ex.InnerException.Message));
                    }
                    else {
                        testNode.Nodes.Add(new TreeNode("msg: " + ex.Message));
                    }

                     results.Nodes.Add(testNode);
                }
                


                testNum++;
            
            }

        }
    }

}

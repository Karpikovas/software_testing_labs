using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public class SimpleTest {

        public SimpleTest(string _namespace, string _class, string _method, string _params,  string _expected) {
            Namespace = _namespace;
            Class = _class;
            Method = _method;
            Params = _params;
            Expected = _expected;
        }

        public string Namespace { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string Params { get; set; }
        public string Expected { get; set; }
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

}

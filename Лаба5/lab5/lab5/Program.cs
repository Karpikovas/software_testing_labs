using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Program
    {
        public static string isPangram(string str)
        {
            char[] alph = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 'x', 't', 'u', 'v', 'w', 's', 'y', 'z' };
            str = str.ToLower();
            int count = 0;

            foreach (char a in alph)
            {
                if (str.Contains(a)) {
                    count++;
                }
            }

            Console.WriteLine(count);
            if (count == 26) return "pangram";
            else return "not pangram";
        }

        static void Main(string[] args) { }
    }
}

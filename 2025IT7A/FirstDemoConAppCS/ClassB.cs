using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoConAppCS
{
    internal class ClassB : IClassDesign<string>
    {
        public string Display()
        {
            return "Hi, I am Display from Class B";
        }

        public string Display(string type)
        {
            return "Your data is " + type;
        }

        public void ShowData()
        {
            Console.WriteLine("Hi, I am Show Data from Class B");
        }
    }
}

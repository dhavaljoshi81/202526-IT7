using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoConAppCS
{
    internal class ClassA : IClassDesign<int>
    {
        public virtual string Display()
        {
            return "Hi, I am Display from Class A";
        }

        public string Display(int type)
        {
            return "Your input is " + type * 10;
        }

        public void ShowData()
        {
            Console.WriteLine("Hi, I am Show Data from Class A");
        }
    }
}

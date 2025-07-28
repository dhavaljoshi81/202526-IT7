using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoConAppCS
{
    internal class ClassA : IClassDesign<int>
    {
        public virtual void DemoMethod()
        {
            Console.WriteLine("Hi, I am Demo Method");
        }

        public string Display()
        {
           return "How are you?";
        }

        public int Display(int type)
        {
           return type * 10;
        }
    }
}

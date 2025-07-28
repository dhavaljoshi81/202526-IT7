using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoConAppCS
{
    internal class ClassB : IClassDesign<int>
    {
        public void DemoMethod()
        {
            Console.WriteLine("Demo Method from Class B");
        }

        public string Display()
        {
            return "Dispaly from Class B";
        }

        public int Display(int type)
        {
            return type * 5;
        }
    }
}

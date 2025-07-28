using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoConAppCS
{
    internal class GenDemo<MyType>
    {
        public MyType Test { get; set; }

        public MyType TestMethod(MyType myType)
        {
            return Test;
        }
        public void GetData()
        {
            Console.WriteLine(Test);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoConAppCS
{
    internal class MyGen<MyType>
    {
        public MyType Test { get; set; }

        public void Display()
        {
            Console.WriteLine("The value of Test is: " + Test);
        }

        public string ChangeValue<T>(T data)
        {
            return "Your data is " + data;
        }
    }
}

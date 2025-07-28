using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoConAppCS
{
    internal class Student : IClassDesign
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void DemoMethod()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Student is " + ID + " : "
                + Name + " : " + Age.ToString();
        }
    }
}

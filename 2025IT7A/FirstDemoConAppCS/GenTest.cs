using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoConAppCS
{
    internal class GenTest
    {
        public string ChangeValue<T>(T data)
        {
            return "Your data is " + data;
        }
    }
}

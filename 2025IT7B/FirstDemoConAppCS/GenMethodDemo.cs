using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoConAppCS
{
    internal class GenMethodDemo
    {
        public string GetValues<T, R>(T a , R r)
        {
            return "Your input is " + a + r;
        }
    }
}

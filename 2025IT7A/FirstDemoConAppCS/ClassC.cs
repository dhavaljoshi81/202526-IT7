using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoConAppCS
{
    internal class ClassC<YourType> : IClassDesign<YourType> where YourType : class, IClassDesign
    {
        public string Display()
        {
            throw new NotImplementedException();
        }

        public string Display(YourType type)
        {
            throw new NotImplementedException();
        }

        public void ShowData()
        {
            throw new NotImplementedException();
        }
    }
}

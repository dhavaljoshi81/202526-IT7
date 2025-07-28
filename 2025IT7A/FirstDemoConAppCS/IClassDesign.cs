using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemoConAppCS
{
    internal interface IClassDesign
    {
       void ShowData();
    }
    internal interface IClassDesign<MyType> : IClassDesign
    {
        string Display();

        string Display(MyType type);
    }
}

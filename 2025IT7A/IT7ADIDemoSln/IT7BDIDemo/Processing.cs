using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT7BDIDemo
{
    public class Processing
    {
        public Processing(IWriter myWriter) 
        {
            writer = myWriter;
        }

        private IWriter writer;

        public IWriter Writer
        {
            set { writer = value; }
        }

        public void PrintMyData(String str)
        {
            Console.WriteLine("This is Print My Data.");
            writer.WriteLog(str);
        }

        public void PrintMyData(String str, IWriter newWriter)
        {
            Console.WriteLine("This is Print My Data.");
            newWriter.WriteLog(str);
        }
    }
}

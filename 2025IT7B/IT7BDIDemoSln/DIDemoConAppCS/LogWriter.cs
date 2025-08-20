using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemoConAppCS
{
    public class LogWriter : IWriter
    {
        public void WriteLog(string message)
        {
            // Simulate writing to a log
            Console.WriteLine($"Log: {message}");
        }
    }
}

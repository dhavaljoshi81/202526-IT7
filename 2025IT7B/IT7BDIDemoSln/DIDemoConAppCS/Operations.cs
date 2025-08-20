using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemoConAppCS
{
    public class Operations
    {
        private IWriter _logWriter;

        public Operations(IWriter myWriter)
        {
            _logWriter = myWriter;
        }

        public IWriter writer { 
            
            set
            {
                _logWriter = value;
            } 
        }
        public void PerformOperation(string operationName)
        {
            // Simulate performing an operation
            Console.WriteLine($"Performing operation: {operationName}");
            _logWriter.WriteLog($"Operation {operationName} performed successfully.");
        }

        public void WriteMyData(int value, IWriter testWriter)
        {
            Console.WriteLine("Writing data from WriteMyData...");
            testWriter.WriteLog("Data written from WriteMyData method." + (value *5));
        }
        public void WriteMyData(int value)
        {
            Console.WriteLine("Writing data from WriteMyData...");
            _logWriter.WriteLog("Data written from WriteMyData method." + (value * 2));
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT7BDIDemo
{
    public class DataWriter : IWriter
    {
        public void WriteLog(string message)
        {
            // Here you can implement the logic to write logs to a file, database, or any other logging system.
            // For demonstration purposes, we'll just print to the console.
            Console.WriteLine($"Data: {message}");
        }
    }
}

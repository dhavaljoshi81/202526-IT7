using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoggerLibraryCS
{
    public  class ErrorInfo
    {
        public string ErrorMessage { get; set; }
        public Exception ExceptionType { get; set; }
        public string StackTrace { get; set; }
        public DateTime ErrorTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoggerLibraryCS
{
    public class AppDataInfo
    {
        public string AppName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public DateTime Timestamp { get; set; }
        
    }
}

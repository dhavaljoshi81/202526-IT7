using System;
using System.Collections.Generic;

namespace AppLoggerSQLServer;

public partial class ErrorLog
{
    public int ErrorId { get; set; }

    public string ErrorMessage { get; set; } = null!;

    public string? ExceptionType { get; set; }

    public string? StackTrace { get; set; }

    public DateTime ErrorTime { get; set; }
}

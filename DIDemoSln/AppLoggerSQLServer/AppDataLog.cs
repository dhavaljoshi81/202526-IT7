using System;
using System.Collections.Generic;

namespace AppLoggerSQLServer;

public partial class AppDataLog
{
    public int Id { get; set; }

    public string AppName { get; set; } = null!;

    public string ClassName { get; set; } = null!;

    public string? MethodName { get; set; }

    public string Message { get; set; } = null!;

    public string? UserName { get; set; }

    public DateTime Timestamp { get; set; }
}

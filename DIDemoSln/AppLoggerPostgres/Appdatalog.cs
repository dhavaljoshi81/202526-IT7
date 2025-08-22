using System;
using System.Collections.Generic;

namespace AppLoggerPostgres;

public partial class Appdatalog
{
    public int Id { get; set; }

    public string Appname { get; set; } = null!;

    public string Classname { get; set; } = null!;

    public string? Methodname { get; set; }

    public string Message { get; set; } = null!;

    public string? Username { get; set; }

    public DateTime Timestamp { get; set; }
}

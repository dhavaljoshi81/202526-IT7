using System;
using System.Collections.Generic;

namespace AppLoggerPostgres;

public partial class Errorlog
{
    public int Errorid { get; set; }

    public string Errormessage { get; set; } = null!;

    public string? Exceptiontype { get; set; }

    public string? Stacktrace { get; set; }

    public DateTime Errortime { get; set; }
}

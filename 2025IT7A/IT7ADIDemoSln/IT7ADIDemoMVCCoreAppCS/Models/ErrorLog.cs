using System;
using System.Collections.Generic;

namespace IT7ADIDemoMVCCoreAppCS.Models;

public partial class ErrorLog
{
    public int Id { get; set; }

    public string ErrorValue { get; set; } = null!;
}

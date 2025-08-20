using System;
using System.Collections.Generic;

namespace IT7B_EFCoreDemoAppCS.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }
}

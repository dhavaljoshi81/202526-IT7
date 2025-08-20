using System;
using System.Collections.Generic;

namespace IT7A_StudentAPI_EFAppCS.SchoolModels;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }
}

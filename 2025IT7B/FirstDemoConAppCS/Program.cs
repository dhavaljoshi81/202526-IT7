using FirstDemoConAppCS;

List<Student> students = new List<Student>();
students.Add(new Student { ID = 1, Name = "Harish", Age = 21 });
students.Add(new Student { ID = 2, Name = "Sheema", Age = 24 });
students.Add(new Student { ID = 3, Name = "Sachin", Age = 23 });
students.Add(new Student { ID = 4, Name = "Vibhuti", Age = 22 });
students.Add(new Student { ID = 5, Name = "Prerna", Age = 25 });
students.Add(new Student { ID = 6, Name = "Suraj", Age = 20 });

var averageAge = students.Average(s => s.Age);
Console.WriteLine("Average Age of Students: " + averageAge);
var studList = from s in students
               where s.Name.Contains("re")
               orderby s.Name
               select s;

foreach (var s in studList)
{
    Console.WriteLine(s);
}

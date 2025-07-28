using FirstDemoConAppCS;

//List<Student> students = new List<Student>();
//students.Add(new Student { ID = 1, Name = "Harish", Age = 25 });
//students.Add(new Student { ID = 2, Name = "Sheema", Age = 24 });
//students.Add(new Student { ID = 3, Name = "Sachin", Age = 23 });
//students.Add(new Student { ID = 4, Name = "Vibhuti", Age = 22 });
//students.Add(new Student { ID = 5, Name = "Prerna", Age = 21 });
//students.Add(new Student { ID = 6, Name = "Suraj", Age = 20 });

//var averageAge = students.Average(s => s.Age);
//Console.WriteLine("Average Age of Students: " + averageAge);
//var studList = from s in students
//                where s.Age > averageAge
//                orderby s.Name
//                select s;

//foreach (var s in studList)
//{
//    Console.WriteLine(s);
//}


//===============================================

//string[] customers = {
//"Harish",
//"Sheema",
//"Sachin",
//"Vibhuti",
//"Prerna",
//"Suraj",
//"Mathuradas"
//};

//var custList = from c in customers
//               where c.Contains("u") || c.Contains("e")
//               orderby c
//               select c;

//foreach (var c in custList)
//{
//    Console.WriteLine(c);
//}


int[] set1 = { 10, 12, 3, 44, 5, 17 };

var selectedNumbers = from n in set1
                   //where n > 10 && n < 20
                   orderby n descending
                   select n;

foreach (var n in selectedNumbers)
{     
    Console.WriteLine(n);
}
Console.WriteLine("=====================================");

int[] set2 = { 10, 12, 33, 44, 50, 17, 70, 12, 33, 44, 5, 17 };


int[] allValues = set1.Intersect(set2).ToArray();


foreach (var n in allValues)
{
    Console.WriteLine(n);
}

Console.WriteLine("=====================================");

List<int> dataValues = (from n in set1.Union(set2)
                       where n > 10 && n < 50
                       select n ).ToList<int>();

foreach (var n in dataValues)
{
    Console.WriteLine(n);
}
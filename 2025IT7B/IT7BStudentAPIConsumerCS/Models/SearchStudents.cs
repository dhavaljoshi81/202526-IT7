namespace IT7BStudentAPIConsumerCS.Models
{
    public class SearchStudents
    {
        public string ?name { get; set; }
        public string ?nameOption { get; set; }

        public int ?minAge { get; set; } = 0;
        public int ?maxAge { get; set; } = int.MaxValue;
    }

    public enum NameOption
    {
        Equals,
        StartWith,
        EndsWith,
        Contains
    }

}

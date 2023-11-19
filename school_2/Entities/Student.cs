namespace school_2.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
        public int Status { get; set; }
    }
}

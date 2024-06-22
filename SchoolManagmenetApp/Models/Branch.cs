namespace SchoolManagmenetApp.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Person>? Persons { get; set; }
    }
}

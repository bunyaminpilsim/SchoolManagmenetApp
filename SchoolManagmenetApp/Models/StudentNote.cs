namespace SchoolManagmenetApp.Models
{
    public class StudentNote
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }
        public int StudentId { get; set; }
        public Person? Person { get; set; }
        public double Note { get; set; }

    }
}

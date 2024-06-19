namespace SchoolManagmenetApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }
        public string? ImgPath { get; set; }
        public IFormFile? File { get; set; }
        public List<StudentNote>? StudentNotes { get; set; }

    }
}

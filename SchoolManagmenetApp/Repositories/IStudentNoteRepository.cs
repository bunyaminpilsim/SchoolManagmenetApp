using SchoolManagmenetApp.Models;

namespace SchoolManagmenetApp.Repositories
{
    public interface IStudentNoteRepository
    {
        void AddStudentNote(StudentNote studentNote);
        void DeleteStudentNote(StudentNote studentNote);
        void UpdateStudentNote(StudentNote studentNote);
        StudentNote GetStudentNoteById(int id);
        List<StudentNote> GetAllStudentNotes();
    }
}

using SchoolManagmenetApp.Models;

namespace SchoolManagmenetApp.Repositories
{
    public class StudentNoteRepository : IStudentNoteRepository
    {
        List<StudentNote> _studentNotes = new List<StudentNote>();
        public void AddStudentNote(StudentNote studentNote)
        {
            _studentNotes.Add(studentNote);
        }

        public void DeleteStudentNote(StudentNote studentNote)
        {
            _studentNotes.Remove(studentNote);
        }

        public List<StudentNote> GetAllStudentNotes()
        {
            return _studentNotes;
        }

        public StudentNote GetStudentNoteById(int id)
        {
            return _studentNotes.FirstOrDefault(s => s.Id == id);
        }

        public void UpdateStudentNote(StudentNote studentNote)
        {
            var exisitingStudentNote = GetStudentNoteById(studentNote.Id);
            if (exisitingStudentNote != null)
            {
                exisitingStudentNote.StudentId = studentNote.StudentId;
                exisitingStudentNote.Person = studentNote.Person;
                exisitingStudentNote.Note = studentNote.Note;
                exisitingStudentNote.Branch = studentNote.Branch;
                exisitingStudentNote.BranchId = studentNote.BranchId;
            }
        }
    }
}

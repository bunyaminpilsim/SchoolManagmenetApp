using Microsoft.AspNetCore.Mvc;
using SchoolManagmenetApp.Models;
using SchoolManagmenetApp.Repositories;

namespace SchoolManagmenetApp.Controllers
{
    public class StudentNoteController : Controller
    {
        private readonly IStudentNoteRepository _studentNoteRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IRoleRepository _roleRepository;

        public StudentNoteController(IStudentNoteRepository studentNoteRepository, IBranchRepository branchRepository,IPersonRepository personRepository, IRoleRepository roleRepository)
        {
            _studentNoteRepository = studentNoteRepository;
            _branchRepository = branchRepository;
            _personRepository = personRepository;
            _roleRepository = roleRepository;
        }

        public IActionResult AddStudentNote()
        {
            ViewBag.Branches = _branchRepository.GetAllBranches();
            ViewBag.Students = _personRepository.GetStudent();
            ViewBag.Roles= _roleRepository.GetAllRoles();
            return View();
        }
        [HttpPost]
        public IActionResult AddStudentNote(StudentNote studentNote)
        {
            if(ModelState.IsValid)
            {
                studentNote.Branch = _branchRepository.GetBranchById(studentNote.BranchId);
                studentNote.Person=  _personRepository.GetPersonById(studentNote.StudentId);
                studentNote.Person.Role=_roleRepository.GetRoleById(studentNote.Person.RoleId);
                _studentNoteRepository.AddStudentNote(studentNote);
                return RedirectToAction("StudentNoteList");
            }
            return View(studentNote);
        }

        public IActionResult StudentNoteList()
        {
            var studentNote=_studentNoteRepository.GetAllStudentNotes();
            return View(studentNote);
        }

        public IActionResult DeleteStudentNote(StudentNote studentNote)
        {
            var existingStudentNote=_studentNoteRepository.GetStudentNoteById(studentNote.Id);
            if (existingStudentNote != null)
            {
                _studentNoteRepository.DeleteStudentNote(existingStudentNote);
                return RedirectToAction("StudentNoteList");
            }
            return View(studentNote);
        }

        public IActionResult UpdateStudentNote(int id)
        {
            ViewBag.Branches = _branchRepository.GetAllBranches();
            ViewBag.Roles= _roleRepository.GetAllRoles();
            ViewBag.Students= _personRepository.GetAllPersons();
            var StudentNote = _studentNoteRepository.GetStudentNoteById(id);
            if (StudentNote == null)
            {
                NotFound();
            }
            return View(StudentNote);
        }
        [HttpPost]

        public IActionResult UpdateStudentNote(StudentNote studentNote)
        {
            if (ModelState.IsValid)
            {
                var existingStudentNote = _studentNoteRepository.GetStudentNoteById(studentNote.BranchId);
                if(existingStudentNote==null)
                {
                    NotFound();
                }
                studentNote.Branch = _branchRepository.GetBranchById(studentNote.BranchId);
                studentNote.Person =  _personRepository.GetPersonById(studentNote.StudentId);
                _studentNoteRepository.UpdateStudentNote(studentNote);
                return RedirectToAction("StudentNoteList");
            }
            return View(studentNote);
        }
    }
}

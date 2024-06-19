using Microsoft.AspNetCore.Mvc;
using SchoolManagmenetApp.Models;
using SchoolManagmenetApp.Repositories;

namespace SchoolManagmenetApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IBranchRepository _branchRepository;

        public PersonController(IPersonRepository personRepository, IRoleRepository roleRepository, IBranchRepository branchRepository)
        {
            _personRepository = personRepository;
            _roleRepository = roleRepository;
            _branchRepository = branchRepository;
        }

        public IActionResult AddPerson()
        {
            ViewBag.Roles = _roleRepository.GetAllRoles();
            ViewBag.Branches = _branchRepository.GetAllBranches();
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                if (person.File != null && person.File.Length > 0)
                {
                    string extension = Path.GetExtension(person.File.FileName);
                    string filename = Guid.NewGuid().ToString() + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", filename);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        person.File.CopyTo(stream);
                    }
                    person.ImgPath = "/img/" + filename;
                }
                else
                {
                    ViewBag.Message = "Lütfen bir dosya seçin.";
                    return View(person);
                }

                person.Role = _roleRepository.GetRoleById(person.RoleId);
                person.Branch = _branchRepository.GetBranchById(person.BranchId);
                _personRepository.AddPerson(person);
                return RedirectToAction("PersonList");
            }
            return View(person);
        }

        public IActionResult PersonList()
        {
            var persons = _personRepository.GetAllPersons();
            return View(persons);
        }

        public IActionResult DeletePerson(Person person)
        {
            var existingPerson = _personRepository.GetPersonById(person.Id);
            if (existingPerson != null)
            {
                _personRepository.DeletePerson(existingPerson);
                return RedirectToAction("PersonList");
            }
            return View(person);
        }

        public IActionResult UpdatePerson(int id)
        {
            ViewBag.Roles = _roleRepository.GetAllRoles();
            ViewBag.Branches = _branchRepository.GetAllBranches();
            var person = _personRepository.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost]
        public IActionResult UpdatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                var existingPerson = _personRepository.GetPersonById(person.Id);
                if (existingPerson == null)
                {
                    return NotFound();
                }

                if (person.File != null && person.File.Length > 0)
                {
                    // Eski dosyayı silme
                    if (!string.IsNullOrEmpty(existingPerson.ImgPath))
                    {
                        var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingPerson.ImgPath.TrimStart('/'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    // Yeni dosyayı kaydetme
                    var fileExtension = Path.GetExtension(person.File.FileName);
                    string fileName = Guid.NewGuid().ToString() + fileExtension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        person.File.CopyTo(stream); // .Wait() yerine doğrudan senkron CopyTo kullanıyoruz
                    }
                    person.ImgPath = "/img/" + fileName;
                }
                else
                {
                    person.ImgPath = existingPerson.ImgPath; // Mevcut resmi koruyoruz
                }

                person.Role = _roleRepository.GetRoleById(person.RoleId);
                person.Branch = _branchRepository.GetBranchById(person.BranchId);

                _personRepository.UpdatePerson(person);
                return RedirectToAction("PersonList");
            }
            return View(person);
        }

    }
}
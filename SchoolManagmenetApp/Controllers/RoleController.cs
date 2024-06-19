using Microsoft.AspNetCore.Mvc;
using SchoolManagmenetApp.Models;
using SchoolManagmenetApp.Repositories;

namespace SchoolManagmenetApp.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (ModelState.IsValid)
            {
               
                _roleRepository.AddRole(role);
                return RedirectToAction("RoleList");
            }
            return View(role);
        }

        public IActionResult RoleList()
        {
            var roles = _roleRepository.GetAllRoles();
            return View(roles);
        }

        public IActionResult DeleteRole(Role role)
        {
            var existingRole = _roleRepository.GetRoleById(role.Id);
            if (existingRole != null)
            {
                _roleRepository.DeleteRole(existingRole);
                return RedirectToAction("RoleList");
            }
            return View(role);
        }

        public IActionResult UpdateRole(int id)
        {
            var roles = _roleRepository.GetRoleById(id);
            if (roles == null)
            {
                return NotFound();
            }
            return View(roles);
        }
        [HttpPost]
        public IActionResult UpdateRole(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleRepository.UpdateRole(role);
                return RedirectToAction("RoleList");
            }
            return View(role);
        }
    }
}

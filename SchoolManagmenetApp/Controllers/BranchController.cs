using Microsoft.AspNetCore.Mvc;
using SchoolManagmenetApp.Models;
using SchoolManagmenetApp.Repositories;

namespace SchoolManagmenetApp.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchRepository _branchRepository;

        public BranchController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public IActionResult AddBranch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBranch(Branch branch)
        {
            if (ModelState.IsValid)
            {

                _branchRepository.AddBranch(branch);
                return RedirectToAction("BranchList");
            }
            return View(branch);
        }

        public IActionResult BranchList()
        {
            var branches = _branchRepository.GetAllBranches();
            return View(branches);
        }

        public IActionResult DeleteBranch(Branch branch)
        {
            var existingBranch = _branchRepository.GetBranchById(branch.Id);
            if (existingBranch != null)
            {
                _branchRepository.DeleteBranch(existingBranch);
                return RedirectToAction("BranchList");
            }
            return View(branch);
        }

        public IActionResult UpdateBranch(int id)
        {
            var branches = _branchRepository.GetBranchById(id);
            if (branches == null)
            {
                return NotFound();
            }
            return View(branches);
        }
        [HttpPost]
        public IActionResult UpdateBranch(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchRepository.UpdateBranch(branch);
                return RedirectToAction("BranchList");
            }
            return View(branch);
        }
    }
}

using SchoolManagmenetApp.Models;

namespace SchoolManagmenetApp.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        List<Branch> _branches=new List<Branch>();
        public void AddBranch(Branch branch)
        {
           _branches.Add(branch);
        }

        public void DeleteBranch(Branch branch)
        {
            _branches.Remove(branch);
        }

        public List<Branch> GetAllBranches()
        {
            return _branches;
        }

        public Branch GetBranchById(int id)
        {
            var branch = _branches.FirstOrDefault(x => x.Id == id);
            return branch;
        }

        public void UpdateBranch(Branch branch)
        {
            var existingBranch=GetBranchById(branch.Id);
            if (existingBranch != null)
            {
                existingBranch.Name = branch.Name;
            }
        }
    }
}

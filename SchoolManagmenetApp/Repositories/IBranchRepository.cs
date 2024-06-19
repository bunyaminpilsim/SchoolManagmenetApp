using SchoolManagmenetApp.Models;

namespace SchoolManagmenetApp.Repositories
{
    public interface IBranchRepository
    {
        void AddBranch(Branch branch);
        void DeleteBranch(Branch branch);
        void UpdateBranch(Branch branch);
        Branch GetBranchById(int id);
        List<Branch> GetAllBranches();
    }
}

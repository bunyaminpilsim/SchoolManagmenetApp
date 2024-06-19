using SchoolManagmenetApp.Models;

namespace SchoolManagmenetApp.Repositories
{
    public interface IRoleRepository
    {
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        Role GetRoleById(int id);
        List<Role> GetAllRoles();
    }
}

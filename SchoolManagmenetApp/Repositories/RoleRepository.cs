using SchoolManagmenetApp.Models;

namespace SchoolManagmenetApp.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        List<Role> _roles=new List<Role>();
        public void AddRole(Role role)
        {
            _roles.Add(role);
        }

        public void DeleteRole(Role role)
        {
            _roles.Remove(role);
        }

        public List<Role> GetAllRoles()
        {
            return _roles;
        }

        public Role GetRoleById(int id)
        {
            var role= _roles.FirstOrDefault(r => r.Id == id);
            return role;
        }

        public void UpdateRole(Role role)
        {
            var ExistingRole=GetRoleById(role.Id);
            if (ExistingRole != null)
            {
                ExistingRole.Name = role.Name;
            }
        }
    }
}

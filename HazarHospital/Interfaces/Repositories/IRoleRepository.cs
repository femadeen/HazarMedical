using HazarHospital.Entities;

namespace HazarHospital.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> RegisterRole(Role role);
        Task<Role> FindRoleById(int id);
        Task<Role> FindRoleByName(string name);
        Task<Role> UpdateRole(Role role);
        Task<List<Role>> GetAllRoles();
        Task<bool> DeleteRole(Role role);
    }
}

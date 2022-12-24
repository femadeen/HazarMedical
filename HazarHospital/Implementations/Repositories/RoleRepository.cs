using HazarHospital.Entities;
using HazarHospital.HospitalContext;
using HazarHospital.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarHospital.Implementations.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HazarHospitalDbContext _context;
        public RoleRepository(HazarHospitalDbContext context)
        {
            _context = context;
        }

        public Task<bool> DeleteRole(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> FindRoleByName(string name)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r =>r.Name.ToLower() == name.ToLower());
            return role;
        }

        public Task<List<Role>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public async Task<Role> RegisterRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            _context.SaveChanges();
            return role;
        }

        public Task<Role> UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}

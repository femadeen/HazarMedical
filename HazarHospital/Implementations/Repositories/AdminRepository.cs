using HazarHospital.Entities;
using HazarHospital.HospitalContext;
using HazarHospital.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarHospital.Implementations.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly HazarHospitalDbContext _context;
        public AdminRepository(HazarHospitalDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAdmin(Admin admin)
        {
            _context.Remove(admin);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Exist(string firstName, string lastname)
        {
            var admin = await _context.Admins.AnyAsync(a => a.FirstName.ToLower()
            == firstName.ToLower() && a.LastName.ToLower() == lastname.ToLower());
            return admin;
        }

        public async Task<Admin> FindAdminByEmail(string email)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email.ToLower() == email.ToLower());
            return admin;
        }

        public async Task<Admin> FindAdminById(int id)
        {
            var admin = await _context.Admins.SingleOrDefaultAsync(a => a.Id == id);
            return admin;
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            var admins = await _context.Admins.ToListAsync();
            return admins;
        }

        public async Task<Admin> RegisterAdmin(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
            _context.SaveChanges();
            return admin;
        }

        public async Task<Admin> UpdateAdmin(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
            return admin;

        }
    }
}

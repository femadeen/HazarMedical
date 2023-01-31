using HazarHospital.Entities;
using HazarHospital.HospitalContext;
using HazarHospital.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarHospital.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HazarHospitalDbContext _context;
        
        public UserRepository(HazarHospitalDbContext contect)
        {
            _context = contect;
            
        }

        public Task<bool> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindUserByEmail(string email)
        {
            var user = await _context.Users
                .Include(r => r.Role)
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            return user;

        }

        public async Task<User> FindUserById(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
           var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> RegisterUser(User user)
        {
            _context.Users.AddAsync(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}

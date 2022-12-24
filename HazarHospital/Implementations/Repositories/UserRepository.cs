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
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            return user;

        }

        public Task<User> FindUserById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterUser(User user)
        {
            _context.Users.AddAsync(user);
            _context.SaveChanges();
            return user;
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}

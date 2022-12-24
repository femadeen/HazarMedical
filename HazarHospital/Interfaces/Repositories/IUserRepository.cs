using HazarHospital.Entities;

namespace HazarHospital.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> RegisterUser(User user);
        Task<User> FindUserById(int id);
        Task<User> FindUserByEmail(string email);
        Task<User> UpdateUser(User user);
        public List<User> GetAllUsers();
        Task<bool>DeleteUser(User user);
    }
}

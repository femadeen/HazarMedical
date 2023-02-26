using HazarHospital.Entities;

namespace HazarHospital.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        Task<Admin> RegisterAdmin(Admin admin);
        Task<bool> Exist(string email);
        Task<Admin> FindAdminById(int id);
        Task<Admin> FindAdminByEmail(string email);
        Task<bool> DeleteAdmin(Admin admin);
        Task<Admin> UpdateAdmin(Admin admin);
        Task<List<Admin>> GetAllAdmins();
    }
}

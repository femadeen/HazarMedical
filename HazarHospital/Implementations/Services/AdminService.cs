using HazarHospital.Entities;
using HazarHospital.Interfaces.Repositories;
using HazarHospital.Interfaces.Services;
using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Implementations.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public Task<AdminResponseModel> DeleteAdmin(int adminId)
        {
            throw new NotImplementedException();
        }

        public Task<AdminResponseModel> GetAdminById(int adminId)
        {
            throw new NotImplementedException();
        }

        public Task<AdminsResponseModel> GetAllAdmins()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> RegisterAdmin(RegisterAdminRequestModel model)
        {
            var userExist = await _userRepository.FindUserByEmail(model.Email);
            if(userExist != null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "User Already Exist"
                };
            }
            var adminExist = await _adminRepository.Exist(model.Email);
            if(adminExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Admin already exist"
                };
            }
            var role = await _roleRepository.FindRoleByName("admin");
            var salt = Guid.NewGuid().ToString();
            var hashPassword = BCrypt.Net.BCrypt.HashPassword($"{model.Password}");
            var user = new User
            {
                RoleId = role.Id,
                Email = model.Email,
                HashSalt = salt,
                PasswordHash = hashPassword   
            };
            var admin = new Admin
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                User = user,
                UserId = user.Id,
                AdminCode = $"P{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}{model.FirstName[0]}{model.LastName[0]}",
            };
            await _userRepository.RegisterUser(user);
            await _adminRepository.RegisterAdmin(admin);
            return new BaseResponse
            {
                Status = true,
                Message = " Admin Successfully Registered"
            };
        }

        public Task<BaseResponse> UpdateAdmin(int iD, UpdateAdminRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}

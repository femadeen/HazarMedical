using BCrypt.Net;
using HazarHospital.DTOs;
using HazarHospital.Interfaces.Repositories;
using HazarHospital.Interfaces.Services;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IDoctorRepository _doctorRepository;
        public UserService(IUserRepository userRepository, IAdminRepository adminRepository, IDoctorRepository doctorRepository)
        {
            _userRepository = userRepository;
            _adminRepository = adminRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<UsersResponseModel> GetAllUSers()
        {
            var users = await _userRepository.GetAllUsers();
            return new UsersResponseModel
            {
                Data = users.Select(u => new UserDto
                {
                    Id = u.Id,
                    RoleId = u.RoleId,
                    Email = u.Email,
                    RoleName = u.Role.Name
                }),
                Status = true,
                Message = "All Users retreived successfully"
            };

        }

        public Task<UserResponseModel> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponseModel> Login(LoginRequestModel model)
        {
            var user = await _userRepository.FindUserByEmail(model.Email);
            if(user == null)
            {
                return new UserResponseModel
                {
                    Status = false,
                    Message = "No Such User Exist"
                };
            }
            var passwordCheck = BCrypt.Net.BCrypt.Verify(model.Passwrord, user.PasswordHash);
            if(passwordCheck)
            {
                if(user.Role.Name == "Patient")
                {
                    return new UserResponseModel
                    {
                        Data = new UserDto
                        {
                            Id = user.Id,
                            FirstName = user.Patient.FirstName,
                            LastName = user.Patient.LastName,
                            Email = user.Patient.Email,
                            RoleId = user.Role.Id,
                            RoleName = user.Role.Name
                        },
                        Status = true,
                        Message = "Patient Successfully login"
                    };
                }
                else
                {
                    return new UserResponseModel
                    {
                        Data = new UserDto
                        {
                            Id = user.Id,
                            FirstName = user.Doctor.FirstName,
                            LastName = user.Doctor.LastName,
                            Email = user.Doctor.Email,
                            RoleId = user.Role.Id,
                            RoleName = user.Role.Name
                        },
                        Status = true,
                        Message = "Doctor Successfully login"
                    };
                }
            }
            return new UserResponseModel
            {
                Status = false,
                Message = "UserName / Password is not found"
            };

        }
    }
}

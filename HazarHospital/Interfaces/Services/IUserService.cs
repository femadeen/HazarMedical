using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseModel> Login(LoginRequestModel model);
        Task<UsersResponseModel> GetAllUSers();
        Task<UserResponseModel> GetUserById(int id);
    }
}

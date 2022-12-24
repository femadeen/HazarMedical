using HazarHospital.Interfaces.Services;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Implementations.Services
{
    public class UserService : IUserService
    {
        public Task<UsersResponseModel> GetAllUSers()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseModel> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseModel> Login(LoginRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}

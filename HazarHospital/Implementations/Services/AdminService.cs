using HazarHospital.Interfaces.Services;
using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Implementations.Services
{
    public class AdminService : IAdminService
    {
        public AdminResponseModel DeleteAdmin(int adminId)
        {
            throw new NotImplementedException();
        }

        public AdminResponseModel GetAdminById(int adminId)
        {
            throw new NotImplementedException();
        }

        public AdminsResponseModel GetAllAdmins()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> RegisterAdmin(RegisterAdminRequestModel model)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateAdmin(int iD, UpdateAdminRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}

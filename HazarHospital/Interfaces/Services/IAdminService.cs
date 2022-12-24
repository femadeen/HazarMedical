using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Interfaces.Services
{
    public interface IAdminService
    {
        Task<BaseResponse> RegisterAdmin(RegisterAdminRequestModel model);
        BaseResponse UpdateAdmin(int iD, UpdateAdminRequestModel model);
        AdminResponseModel DeleteAdmin(int adminId);
        AdminResponseModel GetAdminById(int adminId);
        AdminsResponseModel GetAllAdmins();
    }
}

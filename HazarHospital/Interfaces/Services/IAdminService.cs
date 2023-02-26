using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Interfaces.Services
{
    public interface IAdminService
    {
        Task<BaseResponse> RegisterAdmin(RegisterAdminRequestModel model);
        Task<BaseResponse> UpdateAdmin(int iD, UpdateAdminRequestModel model);
        Task<AdminResponseModel> DeleteAdmin(int adminId);
        Task<AdminResponseModel> GetAdminById(int adminId);
        Task<AdminsResponseModel> GetAllAdmins();
    }
}

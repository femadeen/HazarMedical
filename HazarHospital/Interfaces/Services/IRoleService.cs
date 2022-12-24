using HazarHospital.Models;
using HazarHospital.RequstModels;

namespace HazarHospital.Interfaces.Services
{
    public interface IRoleService
    {
        Task<BaseResponse> CreateRole(CreateRoleRequestModel model);
    }
}

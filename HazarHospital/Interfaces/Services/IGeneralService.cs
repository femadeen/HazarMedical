using HazarHospital.ResponseModels;

namespace HazarHospital.Interfaces.Services
{
    public interface IGeneralService
    {
        Task<DashbordResponseModel> Dashboard();
    }
}

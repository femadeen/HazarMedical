using HazarHospital.Models;
using HazarHospital.ResponseModels;

namespace HazarHospital.Interfaces.Services
{
    public interface IPackingService
    {
        Task<BaseResponse> AssignedPackingSpace(int appointmentId);
        Task<PackingsResponseModel> GetAllAvailablePackingSpace();
        Task<BaseResponse> UnassignedPackingSpace(int appointmentId);
        Task<PackingResponseModel> GetPackingSpaceByAppointment(int aapoitmentId);
    }
}

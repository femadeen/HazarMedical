using HazarHospital.Interfaces.Services;
using HazarHospital.Models;
using HazarHospital.ResponseModels;

namespace HazarHospital.Implementations.Services
{
    public class PackingService : IPackingService
    {
        public Task<BaseResponse> AssignedPackingSpace(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<PackingsResponseModel> GetAllAvailablePackingSpace()
        {
            throw new NotImplementedException();
        }

        public Task<PackingResponseModel> GetPackingSpaceByAppointment(int aapoitmentId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UnassignedPackingSpace(int appointmentId)
        {
            throw new NotImplementedException();
        }
    }
}

using HazarHospital.DTOs;
using HazarHospital.Entities;
using HazarHospital.Interfaces.Repositories;
using HazarHospital.Interfaces.Services;
using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Implementations.Services
{
    public class PackingService : IPackingService
    {
        private readonly IPackingRepository _packingRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        public PackingService(IPackingRepository packingRepository, IAppointmentRepository appointmentRepository)
        {
            _packingRepository = packingRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<BaseResponse> AssignedPackingSpace(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<PackingResponseModel> CreatePackingSpace()
        {
           
            var packing = new Packing
            {
                
                IsAssigned = false,
            };
            await _packingRepository.CreatePackingSpace(packing);
            return new PackingResponseModel
            {
                Status = true,
                Message = " Packing Sapce created successfully"
            };
        }

        public async Task<PackingsResponseModel> GetAllAvailablePackingSpace()
        {
            var packing = await _packingRepository.GetAllPAcking();
            var parkAssign = false;
            return new PackingsResponseModel
            {
                Data = packing.Select(p => new PackingDto
                {
                    Id = p.Id,
                    PackingNo = p.PackingNo,
                    IsAssigned = parkAssign
                }).ToList(),
                Status = true,
                Message = "All Available Packings Retreived"
                
            };
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

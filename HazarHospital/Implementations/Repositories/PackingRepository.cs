using HazarHospital.Entities;
using HazarHospital.HospitalContext;
using HazarHospital.Interfaces.Repositories;

namespace HazarHospital.Implementations.Repositories
{
    public class PackingRepository : IPackingRepository
    {
        private readonly HazarHospitalDbContext _context;
        public PackingRepository(HazarHospitalDbContext context)
        {
            _context = context;
        }

        public Task<Packing> CreatePackingSpace(Packing packing)
        {
            throw new NotImplementedException();
        }

        public Task<List<Packing>> GetAllPAcking()
        {
            throw new NotImplementedException();
        }

        public Task<List<Packing>> GetAvailablePAckingSpace()
        {
            throw new NotImplementedException();
        }

        public Task<Packing> GetFirstAvailablePAckingSpace()
        {
            throw new NotImplementedException();
        }

        public Task<Packing> GetPackingByPackingNumber(int packingNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Packing> GetPackingSpace(int packingId)
        {
            throw new NotImplementedException();
        }

        public void RemovePacking(Packing packing)
        {
            throw new NotImplementedException();
        }

        public Task<Packing> UpdatePacking(Packing packing)
        {
            throw new NotImplementedException();
        }
    }
}

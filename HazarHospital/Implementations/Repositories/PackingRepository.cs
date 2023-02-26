using HazarHospital.Entities;
using HazarHospital.HospitalContext;
using HazarHospital.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarHospital.Implementations.Repositories
{
    public class PackingRepository : IPackingRepository
    {
        private readonly HazarHospitalDbContext _context;
        public PackingRepository(HazarHospitalDbContext context)
        {
            _context = context;
        }

        public async Task<Packing> CreatePackingSpace(Packing packing)
        {
            _context.Packings.Add(packing);
            _context.SaveChanges();
            return packing;
        }

        public async Task<List<Packing>> GetAllPAcking()
        {
            var parkings = await _context.Packings.ToListAsync();
            return parkings;
        }

        public async Task<List<Packing>> GetAvailablePAckingSpace()
        {
            var availablePackings = await _context.Packings.Where(p => p.IsAssigned == false).ToListAsync();
            return availablePackings;
        }

        public async Task<Packing> GetFirstAvailablePAckingSpace()
        {
            var availableparking = await _context.Packings.Where(p => p.IsAssigned == false).FirstOrDefaultAsync();
            return availableparking;
        }

        public async Task<Packing> GetPackingByPackingNumber(string  packingNumber)
        {
            var packing = await _context.Packings.SingleOrDefaultAsync(p => p.PackingNo == packingNumber);
            return packing;
        }

        public async  Task<Packing> GetPackingSpace(int packingId)
        {
            var packingSpace = await _context.Packings.SingleOrDefaultAsync(p => p.Id == packingId);
            return packingSpace;
        }

        public async Task<int> GetParkingCount()
        {
            var parkingCount = await _context.Packings.CountAsync();
            return parkingCount;    
        }

        public async Task<bool> RemovePacking(Packing packing)
        {
            var PackingToDelete = _context.Packings.Remove(packing);
            _context.SaveChanges();
            return true;
        }

        public async Task<Packing> UpdatePacking(Packing packing)
        {
           _context.Packings.Update(packing);
            _context.SaveChanges();
            return packing;
        }
    }
}

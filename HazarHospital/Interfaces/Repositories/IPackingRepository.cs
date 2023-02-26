using HazarHospital.Entities;

namespace HazarHospital.Interfaces.Repositories
{
    public interface IPackingRepository
    {
        Task<Packing>CreatePackingSpace(Packing packing);
        Task<Packing> UpdatePacking(Packing packing);
        Task<bool> RemovePacking(Packing packing);
        Task<Packing> GetPackingSpace(int packingId);
        Task<List<Packing>> GetAllPAcking();
        Task<Packing> GetPackingByPackingNumber(string packingNumber);
        Task<List<Packing>> GetAvailablePAckingSpace();
        Task<Packing> GetFirstAvailablePAckingSpace();
        Task<int> GetParkingCount();
    }
}

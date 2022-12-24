using HazarHospital.Entities;
using HazarHospital.HospitalContext;
using HazarHospital.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarHospital.Implementations.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly HazarHospitalDbContext _context;
        public MedicalRecordRepository(HazarHospitalDbContext context)
        {
            _context = context;
        }

        public Task<List<MedicalRecord>> GetAllMedicalRecords()
        {
            throw new NotImplementedException();
        }

        public Task<MedicalRecord> GetMedicalRecordByPatient(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}

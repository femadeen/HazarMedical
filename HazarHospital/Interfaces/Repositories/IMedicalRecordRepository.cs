using HazarHospital.Entities;

namespace HazarHospital.Interfaces.Repositories
{
    public interface IMedicalRecordRepository
    {
        Task<MedicalRecord> GetMedicalRecordByPatient(int patientId);
        Task<List<MedicalRecord>> GetAllMedicalRecords();
    }
}

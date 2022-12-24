using HazarHospital.Entities;

namespace HazarHospital.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> RegisterPatient(Patient patient);
        Task<Patient> FindPatientById(int id);
        Task<Patient> FindpatientByEmail(string email);
        Task<bool> DeletePatient(Patient patient);
        Task<List<Patient>> GetAllPatients();
        Task<bool> Exist(string email);
        Task<Patient> UpdatePatient(Patient patient);
        Task<Patient> GetPatientByPatientCode(string patientCode);
    }
}

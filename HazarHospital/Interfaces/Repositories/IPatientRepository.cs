using HazarHospital.Entities;

namespace HazarHospital.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> RegisterPatient(Patient patient);
        Task<Patient> FindPatientById(int id);
        Task<Patient> FindpatientByEmail(string email);
        Task<bool> DeletePatient(Patient patient);
        Task<bool> Exist(string email);
        Task<int> GetPatientCount();
    }
}

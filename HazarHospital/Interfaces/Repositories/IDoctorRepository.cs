using HazarHospital.Entities;

namespace HazarHospital.Interfaces.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> RegisterDoctor(Doctor doctor);
        Task<Doctor> FindDoctorById(int id);
        Task<Doctor> FindDoctorByEmail(string email);
        Task<bool> DeleteDoctor(Doctor doctor);
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<List<Doctor>> GetAllDoctors();
        Task<bool> Exist(string email);
        Task<bool> CheckAnyAvailableDoctor();
        Task<List<Doctor>> GetDoctorsByDailyHoursOFWork(DateTime dateTime);
        Task<List<Doctor>> GetDoctorsByProffesion(string doctorProffesion);
    }
}

using HazarHospital.Entities;
using HazarHospital.HospitalContext;
using HazarHospital.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarHospital.Implementations.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HazarHospitalDbContext _context;
        public PatientRepository(HazarHospitalDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Exist(string email)
        {
            var patient = await _context.Patients.AnyAsync(p => p.Email.ToLower() == email.ToLower());
            return patient;
        }


        public async Task<Patient> FindpatientByEmail(string email)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Email.ToLower() == email.ToLower());
            return patient;
        }

        public async Task<Patient> FindPatientById(int id)
        {
            var patient = await _context.Patients.SingleOrDefaultAsync(p => p.Id == id);
            return patient;
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return patients;
        }

        public async Task<Patient> GetPatientByPatientCode(string patientCode)
        {
            var patient = await _context.Patients.SingleOrDefaultAsync(p => p.PatientCode == patientCode);
            return patient;
        }

        public async Task<int> GetPatientCount()
        {
            var patientCount = await _context.Patients.CountAsync();
            return patientCount;
        }

        public async Task<Patient> RegisterPatient(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            _context.SaveChanges();
            return patient;

        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
            return patient;
        }
    }
}

using HazarHospital.Entities;
using HazarHospital.HospitalContext;
using HazarHospital.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace HazarHospital.Implementations.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HazarHospitalDbContext _context;
        public  DoctorRepository(HazarHospitalDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckAnyAvailableDoctor()
        {
            var doctor = await _context.Doctors.AnyAsync(d => d.IsAvailable == true);
            return doctor;
        }

        public async Task<bool> DeleteDoctor(Doctor doctor)
        {
            _context.Remove(doctor);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Exist(string email)
        {
            var doctor = await _context.Doctors.AnyAsync(d => d.Email.ToLower() == email.ToLower());
            return doctor;
        }

        public async Task<Doctor> FindDoctorByEmail(string email)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Email == email);
            return doctor;
        }

        public async Task<Doctor> FindDoctorById(int id)
        {
            var doctor = await _context.Doctors.SingleOrDefaultAsync(d => d.Id == id);
            return doctor;
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }


        public async Task<List<Doctor>> GetDoctorsByDailyHoursOFWork(DateTime datetime)
        {
            var doctors = await _context.Doctors.Where(d => d.TotalHoursOfWork == datetime).ToListAsync();
            return doctors;
        }

        public async Task<List<Doctor>> GetDoctorsByProffesion(string doctorProffesion)
        {
            var doctorProfessions = await _context.Doctors.Where(d => d.DoctorProffession.ToLower() == doctorProffesion.ToLower()).ToListAsync();
            return doctorProfessions;
        }

        public async Task<Doctor> RegisterDoctor(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            _context.SaveChanges();
            return doctor;
        }
    }
}

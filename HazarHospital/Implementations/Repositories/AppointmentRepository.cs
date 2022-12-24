using HazarHospital.Entities;
using HazarHospital.HospitalContext;
using HazarHospital.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HazarHospital.Implementations.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HazarHospitalDbContext _context;
        public AppointmentRepository(HazarHospitalDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CancelAppointment(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            return true;
        }

        public async Task<Appointment> Create(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public async Task<IList<Appointment>> GetAllAppoinments()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }

        public async Task<IList<Appointment>> GetAllAppoinmentsByDoctor(int doctorId)
        {
           var appointments = await _context.Appointments.Where(d => d.Id == doctorId).ToListAsync();
            return appointments;
        }

        public Task<IList<Appointment>> GetAllAppoinmentsByPatient(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAppointmentByDoctorByDate(int doctorId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAppointmentByReferenceNumber(string referenceNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetDoctorAvailability(int doctorId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> Update(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}

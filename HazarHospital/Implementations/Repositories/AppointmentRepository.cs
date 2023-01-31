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
           var appointments = await _context.Appointments.Where(a => a.Id == doctorId).ToListAsync();
            return appointments;
        }

        public async Task<IList<Appointment>> GetAllAppoinmentsByPatient(int patientId)
        {
            var appointments = await _context.Appointments.Where(a => a.Id == patientId).ToListAsync();
            return appointments;
        }

        public async Task<Appointment> GetAppointment(int id)
        {
           var appointment = await _context.Appointments.SingleOrDefaultAsync(a => a.Id == id);
            return appointment;
        }

        public async Task<Appointment> GetAppointmentByDoctorByDate(int doctorId, DateTime date)
        {
            var appointment = await _context.Appointments
                .Include(d => d.Doctor)
                .ThenInclude(d => d.Appointments)
                .Include(a => a.AppointmentDate)
                .SingleOrDefaultAsync(a => a.DoctorId == doctorId && a.AppointmentDate == date);
            return appointment;
        }

        public async Task<Appointment> GetAppointmentByReferenceNumber(string referenceNumber)
        {
            var appointment = await _context.Appointments.SingleOrDefaultAsync(a => a.AppointmentReferenceNumber == referenceNumber);
            return appointment;
        }

        public async Task<bool> GetDoctorAvailability(int doctorId, DateTime date)
        {
            var availableDoctor = await _context.Appointments.AnyAsync(a => a.Id == doctorId && a.AppointmentDate == date);
            return availableDoctor;
        }

        public async Task<Appointment> Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
            return appointment;
        }
    }
}

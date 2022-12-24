using HazarHospital.Entities;

namespace HazarHospital.Interfaces.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> Create(Appointment appointment);
        Task<Appointment> Update(Appointment appointment);
        Task<Appointment> GetAppointment(int id);
        Task<IList<Appointment>> GetAllAppoinments();
        Task<bool> CancelAppointment(Appointment appointment);
        Task<IList<Appointment>> GetAllAppoinmentsByPatient(int patientId);
        Task<Appointment> GetAppointmentByReferenceNumber(string referenceNumber);
        Task<Appointment> GetAppointmentByDoctorByDate(int doctorId, DateTime date);
        Task<bool> GetDoctorAvailability(int doctorId, DateTime date);
    }
}

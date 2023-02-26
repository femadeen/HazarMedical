using HazarHospital.Models;

namespace HazarHospital.AppointmentReminder
{
    public interface IAppointmentReminderService 
    {
        Task<bool> ReminderEmail();
    }
}

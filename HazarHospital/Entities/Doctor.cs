using HazarHospital.Enums;
using HazarHospital.Models;

namespace HazarHospital.Entities
{
    public class Doctor : Person
    {
        public string DoctorCode { get; set; }
        public string DoctorProffession { get; set; }
        public DateTime TotalHoursOfWork { get; set; }
        public LabResult LabResult { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public bool IsAvailable { get; set; }
        /*public int appointmentReminderId { get; set; }*/
    }
}

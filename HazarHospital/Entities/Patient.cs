using HazarHospital.Models;

namespace HazarHospital.Entities
{
    public class Patient : Person
    {
        public string PatientCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PatientAddress { get; set; }
        public double? PhoneNumber { get; set; }
        public string Email { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public int appointmentReminderId { get; set; }
    }
}

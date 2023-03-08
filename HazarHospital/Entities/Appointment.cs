using HazarHospital.Enums;

namespace HazarHospital.Entities
{
    public class Appointment
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public string AppointmentReferenceNumber { get; set; }
        public string? AppointmentConfirmationNumber { get; set; }
        public string AppointmentReason { get; set; }
        public DateTime AppointmentDuration { get; set; }
        public bool IsDriving { get; set; }
        public int PatientId { get; set; }
        public int? ParkingId { get; set; }
        public Packing PackingSpace { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime DateCreated { get; set; }
        public AppointmentStatus Status { get; set; }
        public int? DoctorId { get; set; }
       /* public int appointmentReminderId { get; set; }*/
    }
}

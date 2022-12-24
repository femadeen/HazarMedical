namespace HazarHospital.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string AppointmentReason { get; set; }
        public int PatientId { get; set; }
        public PatientDto PatientDto { get; set; }
        public string AppointmentConfirmationNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime DateCreated { get; set; }
        public string DoctorComment { get; set; }
    }
}

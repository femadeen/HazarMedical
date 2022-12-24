namespace HazarHospital.Entities
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}

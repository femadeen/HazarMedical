namespace HazarHospital.DTOs
{
    public class PackingDto
    {
        public int Id { get; set; }
        public AppointmentDto AppointmentDto { get; set; }
        public string PackingNo { get; set; }
        public bool IsAssigned { get; set; }
    }
}

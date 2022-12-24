namespace HazarHospital.Entities
{
    public class Packing
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public string PackingNo { get; set; }
        public bool IsAssigned { get; set; }
    }
}

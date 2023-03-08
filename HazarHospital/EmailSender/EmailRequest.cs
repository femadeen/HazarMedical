namespace HazarHospital.EmailSender
{
    public class EmailRequest
    {
        public int? AppointmentId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverEmailAdrress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}

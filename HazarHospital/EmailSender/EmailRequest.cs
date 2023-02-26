namespace HazarHospital.EmailSender
{
    public class EmailRequest
    {
        public string ReceiverName { get; set; }
        public string ReceiverEmailAdrress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}

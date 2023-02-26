namespace HazarHospital.EmailSender
{
    public interface IEmailSender
    {
        Task <bool> SendEmail (EmailRequest model);
    }
}

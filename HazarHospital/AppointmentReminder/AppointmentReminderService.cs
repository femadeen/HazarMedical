using HazarHospital.EmailSender;
using HazarHospital.Interfaces.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HazarHospital.AppointmentReminder
{
    public class AppointmentReminderService : IAppointmentReminderService
    {
        private readonly IEmailSender _emailSender;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        public AppointmentReminderService(IEmailSender emailSender, IAppointmentRepository appointmentRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
        {
            _emailSender = emailSender;
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> ReminderEmail()
        {
            var appointments = await _appointmentRepository.GetAllAppoinments();
            if(appointments == null)
            {
                return false;
            }
            foreach (var singleAppointment in appointments)
            {
                var appointmentSchedule = singleAppointment.DateCreated.ToString().Split(" ")[0];
                var appointmentDate = DateTime.Parse(appointmentSchedule);
                var stringNowDate = DateTime.Now.ToString().Split(" ")[0];
                var dateNow = DateTime.Parse(stringNowDate);
                /*var appointmentMonth = (appointmentDate.Month + (appointmentDate.Year * 12));
                var nowMonths = (dateNow.Month + (dateNow.Year * 12));*/
                if (dateNow.Day - appointmentDate.Day <= 3)
                {
                    var reminderEmail = new EmailRequest
                    {
                        ReceiverName = $"{singleAppointment.Patient.LastName} {singleAppointment.Patient.FirstName}",
                        ReceiverEmailAdrress = singleAppointment.Patient.Email,
                        Message = "This is to remind you of your appointment with hazar hospital in next three days"
                    };
                    await _emailSender.SendEmail(reminderEmail);
                } 
            }
            return true;

        }
    }

}

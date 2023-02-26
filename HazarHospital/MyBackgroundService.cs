using HazarHospital.AppointmentReminder;
using HazarHospital.EmailSender;
using HazarHospital.HospitalContext;
using HazarHospital.Interfaces.Repositories;

namespace HazarHospital
{
    public class MyBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public MyBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected async override Task ExecuteAsync(CancellationToken token)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HazarHospitalDbContext>();
            var appointmentRepository = scope.ServiceProvider.GetRequiredService<IAppointmentRepository>();
            var patientRepository = scope.ServiceProvider.GetRequiredService<IPatientRepository>();
            var doctorRepository = scope.ServiceProvider.GetRequiredService<IDoctorRepository>();
            var reminderMail = scope.ServiceProvider.GetRequiredService<IAppointmentReminderService>();
            var mail = scope.ServiceProvider.GetRequiredService<IEmailSender>();
            await reminderMail.ReminderEmail();
            System.Console.WriteLine("Hello Hazar hospital user");
            await Task.CompletedTask;
        }


    }
}

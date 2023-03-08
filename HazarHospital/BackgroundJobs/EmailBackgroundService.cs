using HazarHospital.AppointmentReminder;
using HazarHospital.EmailSender;
using HazarHospital.HospitalContext;
using HazarHospital.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using NCrontab;

namespace HazarHospital.BackgroundJobs
{
    public class EmailBackgroundService : BackgroundService
    {
        private readonly CroneConfiguration _configuration;
        private CrontabSchedule _schedule;
        private DateTime _nextRun;

        private readonly ILogger<EmailBackgroundService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;


        public EmailBackgroundService(IServiceScopeFactory serviceScopeFactory, IOptions<CroneConfiguration> configuration, ILogger<EmailBackgroundService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _configuration = configuration.Value;
            _logger = logger;
            _schedule = CrontabSchedule.Parse(_configuration.CronExpression);
            _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Background Hosted Service for {nameof(EmailBackgroundService)}  is starting");
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.UtcNow;
                try
                {
                    using var scope = _serviceScopeFactory.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<HazarHospitalDbContext>();
                    var reminderMail = scope.ServiceProvider.GetRequiredService<IAppointmentReminderService>();
                    await reminderMail.ReminderEmail();
                    /* System.Console.WriteLine("Hello Hazar hospital user");
                     await Task.CompletedTask;*/


                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured while sending mail. {ex.Message}");
                    _logger.LogError(ex, ex.Message);
                }
                _logger.LogInformation($"Background Hosted Service for {nameof(EmailBackgroundService)}  is stopping");
                var timeSpan = _nextRun - now;
                await Task.Delay(timeSpan, stoppingToken);
                _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
            }
        }
    }
}

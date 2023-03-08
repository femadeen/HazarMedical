using HazarHospital;
using HazarHospital.AppointmentReminder;
using HazarHospital.Authentication;
using HazarHospital.BackgroundJobs;
using HazarHospital.EmailSender;
using HazarHospital.HospitalContext;
using HazarHospital.Implementations.Repositories;
using HazarHospital.Implementations.Services;
using HazarHospital.Interfaces.Repositories;
using HazarHospital.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using sib_api_v3_sdk.Client;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(h => h.AddPolicy("hospitalApp", h =>
{
    h.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();
}));

builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPackingService, PackingService>();
builder.Services.AddScoped<IPackingRepository, PackingRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddHostedService<EmailBackgroundService>();
builder.Services.Configure<CroneConfiguration>(builder.Configuration.GetSection("EmailSenderConfig"));
builder.Services.AddScoped<IAppointmentReminderService,AppointmentReminderService>();
builder.Services.AddHttpContextAccessor();
var key = "This is an authorization key";
builder.Services.AddSingleton<IJwtAuthentication>(new JwtAuthentication(key));


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };

    });


builder.Services.AddDbContext<HazarHospitalDbContext>(options => {
    options.UseMySql(builder.Configuration.GetConnectionString("HazarMedicalHospital"), new MySqlServerVersion(new Version(8, 0, 22)));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("hospitalApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

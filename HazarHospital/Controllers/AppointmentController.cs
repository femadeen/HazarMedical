using HazarHospital.Interfaces.Services;
using HazarHospital.RequstModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HazarHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpPost("MakeAppointment")]
        public async Task<IActionResult> MakeAppointment(AppointmentBookingRequestModel model)
        {
            var appointment = await _appointmentService.MakeAppointment(model);
            if(appointment.Status == true)
            {
                return Ok(appointment);
            }
            else
            {
                return BadRequest(appointment);
            }
        }
    }
}

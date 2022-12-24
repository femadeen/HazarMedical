using HazarHospital.Interfaces.Services;
using HazarHospital.RequstModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HazarHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _DoctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _DoctorService = doctorService;
        }

        [HttpPost("RegisterDoctor")]
        public async Task<IActionResult> RegisterDoctor(RegisterDoctorRquestModel model)
        {
            var doctor = await _DoctorService.RegisterDoctor(model);
            if(doctor.Status == true)
            {
                return Ok(doctor);
            }
            else
            {
                return BadRequest(doctor);
            }
               
        }

        [HttpGet("ListOfDoctors")]
        public async Task<IActionResult> ListOfDoctors()
        {
            var doctors = await _DoctorService.GetAllDoctors();
            return Ok(doctors);
        }
    }
}

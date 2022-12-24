using HazarHospital.Interfaces.Services;
using HazarHospital.RequstModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HazarHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("RegisterPatient")]
        public async Task<IActionResult> RegisterPatient(RegisterPatientRequestModel model)
        {
            var patient = await _patientService.RegisterPatient(model);
            if(patient.Status == true)
            {
                return Ok(patient);
            }
            else
            {
                return BadRequest(patient);
            }
        }
    }
}

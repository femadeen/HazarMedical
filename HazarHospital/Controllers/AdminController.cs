using HazarHospital.Interfaces.Services;
using HazarHospital.RequstModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HazarHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin(RegisterAdminRequestModel model)
        {
            var admin = await _adminService.RegisterAdmin(model);
            if(admin.Status == true)
            {
                return Ok(admin);
            }
            else
            {
                return BadRequest(admin);
            }
        }
    }
}

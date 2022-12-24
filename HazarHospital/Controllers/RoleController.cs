using HazarHospital.Interfaces.Services;
using HazarHospital.RequstModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HazarHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("RegisterRole")]
        public async Task<IActionResult> RegisterRole(CreateRoleRequestModel model)
        {
            var role = await _roleService.CreateRole(model);
            return Ok(role);            

        }
    }
}

using HazarHospital.Authentication;
using HazarHospital.Interfaces.Services;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HazarHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtAuthentication _jwt;
        public UserController(IUserService userService, IJwtAuthentication jwt) 
        {
            _userService = userService;
            _jwt = jwt;
        }

        [HttpGet("UserInfo")]
        public async Task<IActionResult> UserInfo()
        {
            int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var loginStatus = await _userService.Login(model);
            if(!loginStatus.Status)
            {
                return BadRequest(loginStatus);
            }
            var token = _jwt.GenerateToken(loginStatus.Data);
            var response = new UserResponseModel
            {
                Data = loginStatus.Data,
                Status = true,
                Message = "User Authenticated"
            };
            return Ok(response);
        }
    }
}

using HazarHospital.Interfaces.Services;
using HazarHospital.RequstModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HazarHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IPackingService _parkingService;
        public ParkingController(IPackingService parkingService)
        {
            _parkingService = parkingService;
        }
        [HttpPost("CreatePacking")]
        public async Task<IActionResult> CreatePacking()
        {
           var packingSpace = await _parkingService.CreatePackingSpace();
           if(packingSpace.Status == true)
            {
                return Ok(packingSpace);
            }
           else
            {
                return BadRequest(packingSpace);
            }
            
        }
    }
}

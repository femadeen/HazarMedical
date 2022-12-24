using HazarHospital.DTOs;
using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class RolesResponseModel : BaseResponse
    {
        public IEnumerable<RoleDto> Data { get; set; } = new List<RoleDto>();
    }
}

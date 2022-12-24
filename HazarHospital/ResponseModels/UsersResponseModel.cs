using HazarHospital.DTOs;
using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class UsersResponseModel : BaseResponse
    {
        public IEnumerable<UserDto> Data { get; set;} = new List<UserDto>();
    }
}

using HazarHospital.DTOs;
using HazarHospital.Models;
namespace HazarHospital.ResponseModels
{
    public class UserResponseModel : BaseResponse
    {
        public UserDto Data {get;set;}
    }
}

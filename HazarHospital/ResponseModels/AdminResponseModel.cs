using HazarHospital.DTOs;
using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class AdminResponseModel : BaseResponse
    {
        public AdminDto Data { get; set; }
    }
}

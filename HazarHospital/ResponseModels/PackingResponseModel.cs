using HazarHospital.DTOs;
using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class PackingResponseModel : BaseResponse
    {
        public PackingDto Data { get; set; }
    }
}

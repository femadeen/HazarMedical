using HazarHospital.DTOs;
using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class AdminsResponseModel : BaseResponse
    {
        public IEnumerable<AdminDto> Data { get; set; } = new List<AdminDto>();
    }
}

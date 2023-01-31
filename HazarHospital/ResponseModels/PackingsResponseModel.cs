using HazarHospital.DTOs;
using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class PackingsResponseModel : BaseResponse
    {
        public IEnumerable<PackingDto> Data { get; set; } = new List<PackingDto>();
    }
}

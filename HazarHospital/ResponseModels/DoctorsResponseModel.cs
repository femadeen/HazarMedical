using HazarHospital.DTOs;
using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class DoctorsResponseModel : BaseResponse
    {
        public IEnumerable<DoctorDto> Data { get; set; } = new List<DoctorDto>();
    }
}

using HazarHospital.DTOs;
using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class DoctorResponseModel : BaseResponse
    {
        public DoctorDto Data { get; set; }
    }
}

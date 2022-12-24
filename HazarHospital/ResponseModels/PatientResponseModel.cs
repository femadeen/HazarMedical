using HazarHospital.DTOs;
using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class PatientResponseModel : BaseResponse
    {
        public PatientDto Data { get; set; }
    }
}

using HazarHospital.DTOs;
using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class PatientsResponseModel : BaseResponse
    {
        public IEnumerable<PatientDto> Data { get; set;} = new List<PatientDto>();
    }
}

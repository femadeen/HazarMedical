using HazarHospital.DTOs;
using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class AppointmentsResponseModel : BaseResponse
    {
        public IEnumerable<AppointmentDto> Data { get; set; } = new List<AppointmentDto>();
    }
}

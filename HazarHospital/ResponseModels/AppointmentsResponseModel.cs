using HazarHospital.DTOs;

namespace HazarHospital.ResponseModels
{
    public class AppointmentsResponseModel
    {
        public IEnumerable<AppointmentDto> Data { get; set; } = new List<AppointmentDto>();
    }
}

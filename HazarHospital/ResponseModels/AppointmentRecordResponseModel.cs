using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class AppointmentRecordResponseModel : BaseResponse
    {
        public int ? AppointmentId { get; set; }
        public string DoctorComment { get; set; }
    }
}

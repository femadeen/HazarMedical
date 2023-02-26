using HazarHospital.Models;

namespace HazarHospital.ResponseModels
{
    public class DashbordResponseModel : BaseResponse
    {
        public int AppointmentCount { get; set; }
        public int PatientCount { get; set; }
        public int ParkingCount { get; set; }
        public int DoctorCount { get; set; }
    }
}

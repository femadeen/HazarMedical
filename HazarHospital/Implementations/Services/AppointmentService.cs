using HazarHospital.Entities;
using HazarHospital.Interfaces.Services;
using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Implementations.Services
{
    public class AppointmentService : IAppointmentService
    {
        public Task<AppointmentResponseModel> AppointmentConfimationNumber(Appointment Apppointment)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> ApprovedAppointment(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentResponseModel> CancelUnappovedAppointment(CancelBookedAppointmentRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> MakeAppointment(AppointmentBookingRequestModel request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> RecommendAppointmentByDoctor(AppointmentBookingRequestModel request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> RequestToCancelApprovedAppointment(CancelBookedAppointmentRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> SubmitAppointmentRecord(string comment, int appointmentId)
        {
            throw new NotImplementedException();
        }
    }
}

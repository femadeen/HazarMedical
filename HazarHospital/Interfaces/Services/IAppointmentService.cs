using HazarHospital.Entities;
using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<BaseResponse> MakeAppointment(AppointmentBookingRequestModel request);
        Task<BaseResponse> ApprovedAppointment(int appointmentId);
        Task<AppointmentRecordResponseModel> SubmitAppointmentRecord(string comment, int appointmentId);
        Task<AppointmentResponseModel> AppointmentConfimationNumber(Appointment Apppointment);
        Task<AppointmentResponseModel> CancelUnappovedAppointment(CancelBookedAppointmentRequestModel model);
        Task<BaseResponse> RecommendAppointmentByDoctor(AppointmentBookingRequestModel request);
        Task<BaseResponse> RequestToCancelApprovedAppointment(CancelBookedAppointmentRequestModel model);
        Task<AppointmentsResponseModel> GetAllAppointments();
    }
}

using HazarHospital.DTOs;
using HazarHospital.Entities;
using HazarHospital.Implementations.Repositories;
using HazarHospital.Interfaces.Repositories;
using HazarHospital.Interfaces.Services;
using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Implementations.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IPackingRepository _packingRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository, IPackingRepository packingRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _packingRepository = packingRepository;
        }
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

        public Task<AppointmentsResponseModel> GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> MakeAppointment(AppointmentBookingRequestModel request)
        {
            var patient = await _patientRepository.FindpatientByEmail(request.Email);
            if(patient == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Paitient not found! Registration is required"
                };
            }
            var parkingSpace = await _packingRepository.GetAvailablePAckingSpace();
            if(request.IsDriving && parkingSpace.Count == 0)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "No Parking space available, Please try another date and time"
                };
            }
            var parkingSpaceNo = await _packingRepository.GetFirstAvailablePAckingSpace();
            if(request.IsDriving == true)
            {
                if (parkingSpaceNo != null)
                {
                    parkingSpaceNo.IsAssigned = true;
                    await _packingRepository.UpdatePacking(parkingSpaceNo);
                }
                else
                {
                    return new BaseResponse
                    {
                        Status = false,
                        Message = "No Packing space Available, Kindly choose another date or time"
                    };
                }

            }
            
            var availableDoctorBaseOnUnit = await _doctorRepository.GetDoctorsByProffesion(request.unitFacility);
            if (availableDoctorBaseOnUnit.Count == 0)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " No availble doctor, please chec back"
                };
            }
            var availableDoctorBaseOnHoursOfWork = await _doctorRepository.GetDoctorsByDailyHoursOFWork(request.AppointmentTime);
            if (availableDoctorBaseOnHoursOfWork == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "No Available doctor"
                };
            }
            var apptConfirmation = $"A{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}" +
                        $"{patient.FirstName[0]}{patient.LastName[0]}";
            var appointment = new Appointment

            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                PatientId = patient.Id,
                AppointmentDate = request.AppointmentTime,
                AppointmentDuration = DateTime.Now.AddHours(2),
                DateCreated = DateTime.Now,
                AppointmentReferenceNumber = Guid.NewGuid().ToString(),
                AppointmentReason = request.ReasonForAppointment,
                DoctorId = availableDoctorBaseOnUnit.First().Id,
                ParkingId = (request.IsDriving == true) ? parkingSpace.First().Id : null,
                Status = Enums.AppointmentStatus.Completed, 
                IsDriving = request.IsDriving,
                AppointmentConfirmationNumber = apptConfirmation,
                
        };
            await _appointmentRepository.Create(appointment);
            return new BaseResponse
            {
                Status = true,
                Message = $"Appointment successfulluy created with confirmation number{apptConfirmation}"
            };
        }

        public Task<BaseResponse> RecommendAppointmentByDoctor(AppointmentBookingRequestModel request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> RequestToCancelApprovedAppointment(CancelBookedAppointmentRequestModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<AppointmentRecordResponseModel> SubmitAppointmentRecord(string comment, int appointmentId)
        {
            var appointment = await _appointmentRepository.GetAppointment(appointmentId); 
            if(appointment == null)
            {
                return new AppointmentRecordResponseModel
                {
                    Status = false,
                    Message = "No such appointment exist"
                };
            }
            if(appointment.Status == Enums.AppointmentStatus.Completed)
            {
                return new AppointmentRecordResponseModel
                {
                    AppointmentId = appointmentId,
                    DoctorComment = comment,
                    Status = true,
                    Message = "Doctor's comment submitted"
                };
            }
            return new AppointmentRecordResponseModel
            {
               Status = false,
               Message = " Treatment not yet complete"
            };
        }
    }
}

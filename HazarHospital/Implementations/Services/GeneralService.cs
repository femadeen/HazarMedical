using HazarHospital.Interfaces.Repositories;
using HazarHospital.Interfaces.Services;
using HazarHospital.ResponseModels;

namespace HazarHospital.Implementations.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPackingRepository _parkingRepository;
        public GeneralService(IAppointmentRepository appointmentRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository, IPackingRepository parkingRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _parkingRepository = parkingRepository;
        }

        public async Task<DashbordResponseModel> Dashboard()
        {
            var appointmentCount = await _appointmentRepository.GetAppointmentCount();
            var patientCount = await _patientRepository.GetPatientCount();
            var  doctorCount = await _doctorRepository.GetDoctorCount();
            var parkingCount = await _parkingRepository.GetParkingCount();
            return new DashbordResponseModel
            {
                AppointmentCount = appointmentCount,
                PatientCount = patientCount,
                DoctorCount = doctorCount,
                ParkingCount = parkingCount,
                Status = true,
                Message = "Count Retreived"
            };
        }
    }
}

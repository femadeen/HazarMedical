using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Interfaces.Services
{
    public interface IPatientService
    {
        Task<BaseResponse> RegisterPatient(RegisterPatientRequestModel model);
        Task<BaseResponse> UpdatePatient(int id, UpdatePatientRequestModel model);
        Task<PatientResponseModel> DeletePatient(int patientId);
        Task<PatientResponseModel> GetPatientById(int patientId);
        Task<PatientsResponseModel> GetAllPatients();
    }
}

using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Interfaces.Services
{
    public interface IDoctorService
    {
        Task<BaseResponse> RegisterDoctor(RegisterDoctorRquestModel model);
        Task<BaseResponse> UpdateDoctor(int Id, UpdateDoctorRequestModel model);
        Task<DoctorResponseModel> GetDoctorById(int id);
        Task<DoctorResponseModel> GetDocotrByProffession(String DoctorProffession);
        Task<DoctorsResponseModel> GetAllDoctors();
        Task<DoctorResponseModel> DeleteDoctor(int id);
        Task<BaseResponse> AdmitPatient(int appointmentId);
    }
}

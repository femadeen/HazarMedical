using HazarHospital.Entities;
using HazarHospital.Interfaces.Repositories;
using HazarHospital.Interfaces.Services;
using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;

namespace HazarHospital.Implementations.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public PatientService(IPatientRepository patientRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public Task<PatientResponseModel> DeletePatient(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<PatientsResponseModel> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Task<PatientResponseModel> GetPatientById(int patientId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> RegisterPatient(RegisterPatientRequestModel model)
        {
            var userExist = await _userRepository.FindUserByEmail(model.Email);
            if(userExist != null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Sorry! User already exist"
                };
            }
            var patientExist = await _patientRepository.Exist(model.Email);
            if(patientExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " Sorry! Patient already exist"
                };
            }
            var role = await _roleRepository.FindRoleByName("Patient");
            var salt = Guid.NewGuid().ToString();
            var hashPassword = BCrypt.Net.BCrypt.HashPassword($"{model.password}");
            var user = new User
            {
                Email = model.Email,
                RoleId = role.Id,
                HashSalt = salt,
                PasswordHash = hashPassword
            };
            var patient = new Patient
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                PatientAddress = model.PatientAddress,
                PhoneNumber = model.PhoneNumber,
                User = user,
                UserId = user.Id,
                PatientCode = $"P{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}{model.FirstName[0]}{model.LastName[0]}",
            };
            await _userRepository.RegisterUser(user);
            await _patientRepository.RegisterPatient(patient);
            return new BaseResponse
            {
                Status = true,
                Message = "Patient Registered Successfully"
            };
        }

        public Task<BaseResponse> UpdatePatient(int id, UpdatePatientRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}

using HazarHospital.DTOs;
using HazarHospital.Entities;
using HazarHospital.Interfaces.Repositories;
using HazarHospital.Interfaces.Services;
using HazarHospital.Models;
using HazarHospital.RequstModels;
using HazarHospital.ResponseModels;
using System.Net.WebSockets;

namespace HazarHospital.Implementations.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        public DoctorService(IDoctorRepository doctorRepository, IUserRepository userRepository, IRoleRepository roleRepository, IAppointmentRepository appointmentRepository, IPatientRepository patientRepository)
        {
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
        }

        public Task<BaseResponse> AdmitPatient(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorResponseModel> DeleteDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DoctorsResponseModel> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetAllDoctors();
            var retrunDoctors = doctors.Select(d => new DoctorDto
            {
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email,
                DoctorProfession = d.DoctorProffession
            });
            return new DoctorsResponseModel
            {
                Data = retrunDoctors,
                Status = true,
                Message = "All doctors retreived successfully"
            };
        }

        public Task<DoctorResponseModel> GetDocotrByProffession(string DoctorProffession)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorResponseModel> GetDoctorById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> RegisterDoctor(RegisterDoctorRquestModel model)
        {
            var userExist = await _userRepository.FindUserByEmail(model.Email);
            if (userExist != null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "User already exist"
                };
            }
            var doctorExist = await _doctorRepository.FindDoctorByEmail(model.Email);
            if (doctorExist != null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Doctor already exist"
                };
            }
            var role = await _roleRepository.FindRoleByName("Doctor");
            if(role == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "No such Role found"
                };
            }
            var salt = Guid.NewGuid().ToString();
            var hashpassword = BCrypt.Net.BCrypt.HashPassword($"{model.Password}{salt}");
            var user = new User
            {
                Email = model.Email,
                RoleId = role.Id,
                HashSalt = salt,
                PasswordHash = hashpassword
            };
            var doctor = new Doctor
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                User = user,
                UserId = user.Id,
                DoctorProffession = model.Proffession,
                DoctorCode = $"D{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}{model.FirstName[0]}{model.LastName[0]}",
            };
            await _userRepository.RegisterUser(user);
            await _doctorRepository.RegisterDoctor(doctor);
            return new BaseResponse
            {
                Status = true,
                Message = "Doctor successully registered"
            };
        }

        public Task<BaseResponse> UpdateDoctor(int Id, UpdateDoctorRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}

using HazarHospital.Entities;
using HazarHospital.Interfaces.Repositories;
using HazarHospital.Interfaces.Services;
using HazarHospital.Models;
using HazarHospital.RequstModels;

namespace HazarHospital.Implementations.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse> CreateRole(CreateRoleRequestModel model)
        {
            var role = new Role
            {
                Name = model.RoleName
            };
            await _roleRepository.RegisterRole(role);
            return new BaseResponse
            {
                Status = true,
                Message = " Role Registered successfully"
            };
        }
    }
}

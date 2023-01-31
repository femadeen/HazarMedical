using HazarHospital.DTOs;
using HazarHospital.ResponseModels;

namespace HazarHospital.Authentication
{
    public interface IJwtAuthentication
    {
        string GenerateToken(UserDto model );
    }
}

using HazarHospital.DTOs;

namespace HazarHospital.ResponseModels
{
    public class PackingsResponseModel
    {
        public IEnumerable<PackingDto> Data { get; set; } = new List<PackingDto>();
    }
}

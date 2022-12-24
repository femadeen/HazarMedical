namespace HazarHospital.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserDto> Users { get; set; } = new List<UserDto>();
    }
}

namespace HazarHospital.RequstModels
{
    public class RegisterPatientRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PatientAddress { get; set; }
        public double PhoneNumber { get; set; }
    }
}

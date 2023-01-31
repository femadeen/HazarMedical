namespace HazarHospital.RequstModels
{
    public class AppointmentBookingRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string unitFacility { get; set; }
        public bool IsDriving { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string ReasonForAppointment { get; set; }
    }
}

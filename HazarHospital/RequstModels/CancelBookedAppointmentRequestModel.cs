namespace HazarHospital.RequstModels
{
    public class CancelBookedAppointmentRequestModel
    {
        public int AppointmentId { get; set; }
        public string ReasonForCancleAppointment { get; set; }
    }
}

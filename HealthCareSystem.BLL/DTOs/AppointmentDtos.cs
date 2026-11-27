namespace HealthCareSystem.BLL.DTOs
{
    public record GetAppointmentResponse(int PatientId, string PatientName, int DoctorId, string DoctorName, DateTime AppointmentDate);
    public record CreateAppointmentRequest(int PatientId, int DoctorId, DateTime AppointmentDate);
}
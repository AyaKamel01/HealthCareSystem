namespace HealthCareSystem.BLL.DTOs
{
    public record GetDoctorResponse(int Id, string Name, string Specialization);
    public record CreateDoctorRequest(string Name, string Specialization);
    public record UpdateDoctorRequest(int Id, string Name, string Specialization);
}
namespace HealthCareSystem.BLL.DTOs
{
    public record GetPatientResponse(int Id, string Name, DateTime DateOfBirth);
    public record CreatePatientRequest(string Name, DateTime DateOfBirth);
    public record UpdatePatientRequest(int Id, string Name, DateTime DateOfBirth);
}
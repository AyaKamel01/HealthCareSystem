namespace HealthCareSystem.BLL.DTOs
{
    public record UserRegisterRequest(string Email, string Password);
    public record UserLoginRequest(string Email, string Password);
}
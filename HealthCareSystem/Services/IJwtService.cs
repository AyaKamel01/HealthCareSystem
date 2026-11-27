using HealthCareSystem.DAL.Entities;

namespace HealthCareSystem.api.Services
{
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser user);
    }
}
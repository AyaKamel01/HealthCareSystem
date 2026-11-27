using Microsoft.AspNetCore.Identity;

namespace HealthCareSystem.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
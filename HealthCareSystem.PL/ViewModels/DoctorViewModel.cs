using System.ComponentModel.DataAnnotations;

namespace HealthCareSystem.PL.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Doctor Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Specialization")]
        public string Specialization { get; set; } = string.Empty;
    }
}
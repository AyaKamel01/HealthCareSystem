using System.ComponentModel.DataAnnotations;

namespace HealthCareSystem.PL.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Patient Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
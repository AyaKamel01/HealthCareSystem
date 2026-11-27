using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealthCareSystem.PL.ViewModels
{
    public class AppointmentViewModel
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public int DoctorId { get; set; }

        public string DoctorName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        public IEnumerable<SelectListItem> Patients { get; set; }
            = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Doctors { get; set; }
            = new List<SelectListItem>();
    }
}
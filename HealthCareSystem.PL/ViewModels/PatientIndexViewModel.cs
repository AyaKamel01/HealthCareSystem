namespace HealthCareSystem.PL.ViewModels
{
    public class PatientIndexViewModel
    {
        public IEnumerable<PatientViewModel> Patients { get; set; }
            = new List<PatientViewModel>();

        public string? SearchTerm { get; set; }

        public int PageIndex { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;
    }
}
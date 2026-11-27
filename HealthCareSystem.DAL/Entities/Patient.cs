namespace HealthCareSystem.DAL.Entities
{
    public class Patient : BaseEntity
    {
        public required string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
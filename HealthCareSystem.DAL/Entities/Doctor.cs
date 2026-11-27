namespace HealthCareSystem.DAL.Entities
{
    public class Doctor : BaseEntity
    {
        public required string Name { get; set; }
        public required string Specialization { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
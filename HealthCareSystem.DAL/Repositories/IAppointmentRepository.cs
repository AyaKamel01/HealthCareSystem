using HealthCareSystem.DAL.Entities;

namespace HealthCareSystem.DAL.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetAsync(int patientId, int doctorId, DateTime appointmentDate);
        Task<bool> ExistsAsync(int patientId, int doctorId, DateTime appointmentDate);
        Task<Appointment> CreateAsync(Appointment appointment);
        Task<bool> DeleteAsync(int patientId, int doctorId, DateTime appointmentDate);
    }
}
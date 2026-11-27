using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.BLL.Results;

namespace HealthCareSystem.BLL.Services
{
    public interface IAppointmentService
    {
        Task<GenericResult<IEnumerable<GetAppointmentResponse>>> GetAllAsync();
        Task<GenericResult<GetAppointmentResponse>> GetAsync(int patientId, int doctorId, DateTime appointmentDate);
        Task<GenericResult<GetAppointmentResponse>> CreateAsync(CreateAppointmentRequest request);
        Task<Result> DeleteAsync(int patientId, int doctorId, DateTime appointmentDate);
    }
}
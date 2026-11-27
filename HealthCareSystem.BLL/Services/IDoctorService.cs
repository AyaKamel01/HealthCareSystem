using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.BLL.Results;

namespace HealthCareSystem.BLL.Services
{
    public interface IDoctorService
    {
        Task<GenericResult<IEnumerable<GetDoctorResponse>>> GetAllAsync();
        Task<GenericResult<GetDoctorResponse>> GetByIdAsync(int id);
        Task<GenericResult<GetDoctorResponse>> CreateAsync(CreateDoctorRequest request);
        Task<Result> UpdateAsync(UpdateDoctorRequest request);
        Task<Result> DeleteAsync(int id);
    }
}
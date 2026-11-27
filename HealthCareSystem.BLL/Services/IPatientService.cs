using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.BLL.Results;

namespace HealthCareSystem.BLL.Services
{
    public interface IPatientService
    {
        Task<GenericResult<IEnumerable<GetPatientResponse>>> GetAllAsync();
        Task<GenericResult<GetPatientResponse>> GetByIdAsync(int id);
        Task<GenericResult<GetPatientResponse>> CreateAsync(CreatePatientRequest request);
        Task<Result> UpdateAsync(UpdatePatientRequest request);
        Task<Result> DeleteAsync(int id);
    }
}
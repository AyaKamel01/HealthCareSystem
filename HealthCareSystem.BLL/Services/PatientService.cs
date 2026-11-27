using AutoMapper;
using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.BLL.Results;
using HealthCareSystem.DAL.Entities;
using HealthCareSystem.DAL.Repositories;

namespace HealthCareSystem.BLL.Services
{
    public class PatientService(IGenericRepository<Patient> repository, IMapper mapper) : IPatientService
    {
        public async Task<GenericResult<IEnumerable<GetPatientResponse>>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var response = mapper.Map<IEnumerable<GetPatientResponse>>(entities);
            return GenericResult<IEnumerable<GetPatientResponse>>.Success(response);
        }

        public async Task<GenericResult<GetPatientResponse>> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync(id);

            if (entity is null)
                return GenericResult<GetPatientResponse>.Failure($"Patient with Id = {id} is not found.");

            return GenericResult<GetPatientResponse>.Success(mapper.Map<GetPatientResponse>(entity));
        }

        public async Task<GenericResult<GetPatientResponse>> CreateAsync(CreatePatientRequest request)
        {
            var entity = mapper.Map<Patient>(request);
            var created = await repository.CreateAsync(entity);
            return GenericResult<GetPatientResponse>.Success(mapper.Map<GetPatientResponse>(created));
        }

        public async Task<Result> UpdateAsync(UpdatePatientRequest request)
        {
            var entity = await repository.GetByIdAsync(request.Id);

            if (entity is null)
                return Result.Failure($"Patient with Id = {request.Id} is not found.");

            mapper.Map(request, entity);
            await repository.UpdateAsync(entity);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var deleted = await repository.DeleteAsync(id);

            return deleted
                ? Result.Success()
                : Result.Failure($"Patient with Id = {id} is not found.");
        }
    }
}
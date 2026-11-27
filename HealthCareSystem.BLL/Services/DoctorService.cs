using AutoMapper;
using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.BLL.Results;
using HealthCareSystem.DAL.Entities;
using HealthCareSystem.DAL.Repositories;

namespace HealthCareSystem.BLL.Services
{
    public class DoctorService(IGenericRepository<Doctor> repository, IMapper mapper) : IDoctorService
    {
        public async Task<GenericResult<IEnumerable<GetDoctorResponse>>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var response = mapper.Map<IEnumerable<GetDoctorResponse>>(entities);
            return GenericResult<IEnumerable<GetDoctorResponse>>.Success(response);
        }

        public async Task<GenericResult<GetDoctorResponse>> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync(id);

            if (entity is null)
                return GenericResult<GetDoctorResponse>.Failure($"Doctor with Id = {id} is not found.");

            return GenericResult<GetDoctorResponse>.Success(mapper.Map<GetDoctorResponse>(entity));
        }

        public async Task<GenericResult<GetDoctorResponse>> CreateAsync(CreateDoctorRequest request)
        {
            var entity = mapper.Map<Doctor>(request);
            var created = await repository.CreateAsync(entity);
            return GenericResult<GetDoctorResponse>.Success(mapper.Map<GetDoctorResponse>(created));
        }

        public async Task<Result> UpdateAsync(UpdateDoctorRequest request)
        {
            var entity = await repository.GetByIdAsync(request.Id);

            if (entity is null)
                return Result.Failure($"Doctor with Id = {request.Id} is not found.");

            mapper.Map(request, entity);
            await repository.UpdateAsync(entity);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var deleted = await repository.DeleteAsync(id);

            return deleted
                ? Result.Success()
                : Result.Failure($"Doctor with Id = {id} is not found.");
        }
    }
}
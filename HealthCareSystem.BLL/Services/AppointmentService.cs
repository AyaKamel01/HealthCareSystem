using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.BLL.Results;
using HealthCareSystem.DAL.Entities;
using HealthCareSystem.DAL.Repositories;

namespace HealthCareSystem.BLL.Services
{
    public class AppointmentService(
        IAppointmentRepository repository,
        IGenericRepository<Patient> patientRepository,
        IGenericRepository<Doctor> doctorRepository) : IAppointmentService
    {
        public async Task<GenericResult<IEnumerable<GetAppointmentResponse>>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            var response = entities.Select(ToResponse);
            return GenericResult<IEnumerable<GetAppointmentResponse>>.Success(response);
        }

        public async Task<GenericResult<GetAppointmentResponse>> GetAsync(int patientId, int doctorId, DateTime appointmentDate)
        {
            var entity = await repository.GetAsync(patientId, doctorId, appointmentDate);

            if (entity is null)
                return GenericResult<GetAppointmentResponse>.Failure("Appointment is not found.");

            return GenericResult<GetAppointmentResponse>.Success(ToResponse(entity));
        }

        public async Task<GenericResult<GetAppointmentResponse>> CreateAsync(CreateAppointmentRequest request)
        {
            var patient = await patientRepository.GetByIdAsync(request.PatientId);
            if (patient is null)
                return GenericResult<GetAppointmentResponse>.Failure($"Patient with Id = {request.PatientId} is not found.");

            var doctor = await doctorRepository.GetByIdAsync(request.DoctorId);
            if (doctor is null)
                return GenericResult<GetAppointmentResponse>.Failure($"Doctor with Id = {request.DoctorId} is not found.");

            if (await repository.ExistsAsync(request.PatientId, request.DoctorId, request.AppointmentDate))
                return GenericResult<GetAppointmentResponse>.Failure("This appointment already exists.");

            var entity = new Appointment
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                AppointmentDate = request.AppointmentDate
            };

            await repository.CreateAsync(entity);

            var created = await repository.GetAsync(request.PatientId, request.DoctorId, request.AppointmentDate);
            return GenericResult<GetAppointmentResponse>.Success(ToResponse(created!));
        }

        public async Task<Result> DeleteAsync(int patientId, int doctorId, DateTime appointmentDate)
        {
            var deleted = await repository.DeleteAsync(patientId, doctorId, appointmentDate);

            return deleted
                ? Result.Success()
                : Result.Failure("Appointment is not found.");
        }

        private static GetAppointmentResponse ToResponse(Appointment a)
            => new(a.PatientId, a.Patient.Name, a.DoctorId, a.Doctor.Name, a.AppointmentDate);
    }
}
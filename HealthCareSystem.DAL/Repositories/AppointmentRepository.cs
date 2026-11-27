using HealthCareSystem.DAL.Data;
using HealthCareSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.DAL.Repositories
{
    public class AppointmentRepository(AppDbContext dbContext) : IAppointmentRepository
    {
        public async Task<IEnumerable<Appointment>> GetAllAsync()
            => await dbContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();

        public async Task<Appointment?> GetAsync(int patientId, int doctorId, DateTime appointmentDate)
            => await dbContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.PatientId == patientId
                                       && a.DoctorId == doctorId
                                       && a.AppointmentDate == appointmentDate);

        public async Task<bool> ExistsAsync(int patientId, int doctorId, DateTime appointmentDate)
            => await dbContext.Appointments
                .AnyAsync(a => a.PatientId == patientId
                            && a.DoctorId == doctorId
                            && a.AppointmentDate == appointmentDate);

        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            await dbContext.Appointments.AddAsync(appointment);
            await dbContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<bool> DeleteAsync(int patientId, int doctorId, DateTime appointmentDate)
        {
            var entity = await GetAsync(patientId, doctorId, appointmentDate);

            if (entity is null)
                return false;

            dbContext.Appointments.Remove(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
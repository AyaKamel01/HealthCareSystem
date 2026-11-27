using HealthCareSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareSystem.DAL.Data.Configurations
{
    public class AppointmentConfigurations : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => new { a.PatientId, a.DoctorId, a.AppointmentDate });

            builder.HasQueryFilter(a => !a.Patient.IsDeleted && !a.Doctor.IsDeleted);
        }
    }
}
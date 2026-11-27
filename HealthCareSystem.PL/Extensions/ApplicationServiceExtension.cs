using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using HealthCareSystem.BLL.Mapping;
using HealthCareSystem.BLL.Services;

using HealthCareSystem.DAL.Data;
using HealthCareSystem.DAL.Data.Interceptors;
using HealthCareSystem.DAL.Repositories;

using HealthCareSystem.PL.Mapping;

using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.PL.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Database Configuration
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));

                options.AddInterceptors(
                    new SoftDeleteInterceptor(),
                    new CreatedAtInterceptor(),
                    new ModifiedAtInterceptor());
            });

            // AutoMapper Configuration
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<PatientProfile>();
                cfg.AddProfile<DoctorProfile>();
                cfg.AddProfile<PatientViewModelProfile>();
                cfg.AddProfile<DoctorViewModelProfile>();
                cfg.AddProfile<AppointmentViewModelProfile>();
            });

            // Repositories
            services.AddScoped(
                typeof(IGenericRepository<>),
                typeof(GenericRepository<>));

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            // Services
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();

            return services;
        }
    }
}
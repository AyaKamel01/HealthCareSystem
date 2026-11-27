using AutoMapper;
using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.PL.ViewModels;

namespace HealthCareSystem.PL.Mapping
{
    public class AppointmentViewModelProfile : Profile
    {
        public AppointmentViewModelProfile()
        {
            CreateMap<GetAppointmentResponse, AppointmentViewModel>();

            CreateMap<AppointmentViewModel, CreateAppointmentRequest>();
        }
    }
}
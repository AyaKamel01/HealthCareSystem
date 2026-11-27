using AutoMapper;
using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.PL.ViewModels;

namespace HealthCareSystem.PL.Mapping
{
    public class DoctorViewModelProfile : Profile
    {
        public DoctorViewModelProfile()
        {
            CreateMap<GetDoctorResponse, DoctorViewModel>();

            CreateMap<DoctorViewModel, CreateDoctorRequest>();

            CreateMap<DoctorViewModel, UpdateDoctorRequest>();
        }
    }
}
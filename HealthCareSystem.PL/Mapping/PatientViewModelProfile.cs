using AutoMapper;
using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.PL.ViewModels;

namespace HealthCareSystem.PL.Mapping
{
    public class PatientViewModelProfile : Profile
    {
        public PatientViewModelProfile()
        {
            CreateMap<GetPatientResponse, PatientViewModel>();

            CreateMap<PatientViewModel, CreatePatientRequest>();

            CreateMap<PatientViewModel, UpdatePatientRequest>();
        }
    }
}
using AutoMapper;
using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.DAL.Entities;

namespace HealthCareSystem.BLL.Mapping
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, GetDoctorResponse>();
            CreateMap<CreateDoctorRequest, Doctor>();
            CreateMap<UpdateDoctorRequest, Doctor>();
        }
    }
}
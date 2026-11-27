using AutoMapper;
using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.DAL.Entities;

namespace HealthCareSystem.BLL.Mapping
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, GetPatientResponse>();
            CreateMap<CreatePatientRequest, Patient>();
            CreateMap<UpdatePatientRequest, Patient>();
        }
    }
}
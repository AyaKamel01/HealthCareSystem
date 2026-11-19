using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCareSystem.DAL.Entities
{
    public class Doctor
    {
        public  int Id { get; set; }
        public required string Name { get; set; }
        public required  string Specialization { get; set; }
        public ICollection <Appointment> Appointments { get; set; } = new List<Appointment>(); 
    }

}

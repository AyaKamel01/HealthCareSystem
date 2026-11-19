using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCareSystem.DAL.Entities
{
    public class Patient
    {

        public  int Id { get; set; }
        public  required string Name { get; set; } 
        public  DateTime DateOfBirth { get; set; }

        public  ICollection <Appointment> Appointments { get; set; } = new List<Appointment>(); 

    }
}

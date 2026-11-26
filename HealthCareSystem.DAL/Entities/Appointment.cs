using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCareSystem.DAL.Entities
{
    public  class Appointment
    //PatientId, DoctorId, AppointmentDate
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; } 
        public Patient Patient { get; set; } =null!;
        public Doctor Doctor { get; set; } = null!; 
        public  DateTime AppointmentDate { get; set; }


    }
}

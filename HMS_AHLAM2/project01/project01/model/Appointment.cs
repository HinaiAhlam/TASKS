using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.model
{
    public class Appointment
    {
        public int AppointmentId { get; set; }// system generated
        public int PatientId { get; set; }//user input 
        public int DoctorId { get; set; }//system calculated from slotId
        public string? AppointmentDate { get; set; }//system calculated
        public string? AppointmentTime { get; set; }//system calculated
        public string? Status { get; set; } // default value "Scheduled" ==> | "Completed" | "Cancelled"
        public int SlotId { get; set; }// user input choosen from List of availeslots

    }
}

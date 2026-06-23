using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.model
{
    public class AvailableSlot
    {
        public int SlotId { get; set; }//System generated
        public int DoctorId { get; set; }//user input choosen from list of doctors 
        public string? SlotDate { get; set; }//user input optional vaule
        public string? SlotTime { get; set; }
        public bool IsBooked { get; set; }//default value = false

    }
}

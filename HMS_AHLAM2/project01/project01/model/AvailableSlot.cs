using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.model
{
    public class AvailableSlot
    {
        public int SlotId { get; set; }
        public int DoctorId { get; set; }
        public string? SlotDate { get; set; }
        public string? SlotTime { get; set; }
        public bool IsBooked { get; set; }

    }
}

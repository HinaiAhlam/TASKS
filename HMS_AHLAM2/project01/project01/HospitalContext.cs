
using project01.model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01
{
    public class HospitalContext
    {

        public List<Patient> Patients { get; set; } = new List<Patient>();
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public List<AvailableSlot> AvailableSlots { get; set; } = new List<AvailableSlot>();
        public List<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    }
}

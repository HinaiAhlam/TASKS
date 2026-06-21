using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.model
{
    public class MedicalRecord
    {
        public int RecordId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public string? Diagnosis {  get; set; }
        public string? Prescription { get; set; }
        public string? VisitDate { get; set; }
        public decimal VisitFee { get; set; }

    }
}

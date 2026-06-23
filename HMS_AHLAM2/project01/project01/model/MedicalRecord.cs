using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.model
{
    public class MedicalRecord
    {
        public int RecordId { get; set; }//generated
        public int PatientId { get; set; }// system calcualted
        public int DoctorId { get; set; }// system calcualted
        public int AppointmentId { get; set; }// user input 
        public string? Diagnosis {  get; set; }// user input 
        public string? Prescription { get; set; }// user input 
        public string? VisitDate { get; set; }// system calcualted
        public decimal VisitFee { get; set; }// system calcualted

    }
}

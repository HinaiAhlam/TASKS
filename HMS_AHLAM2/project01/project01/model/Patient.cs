using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.model
{
    public class Patient
    {
        public int PatientId {  get; set; }// system generated
        public string? PatientName { get; set; }
        public int PatientAge { get; set; }
        public string? PatientGender { get; set; }
        public string? PatientPhone { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientBloodType { get; set; }
       
        //public List<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        //public Patient() { }
        //public Patient(int id, string Name, int age,
        //                   string Gender, string PhoneNumber, string Email,string BloodType)
        //{
        //    PatientId = id;
        //    PatientName = Name;
        //    PatientAge = age;
        //    PatientGender = Gender;
        //    PatientPhone = PhoneNumber;
        //    PatientEmail = Email;
        //    PatientBloodType = BloodType;
        //}

        //public override string ToString() =>
        //                       $"[{PatientId}] {PatientName,-10} | {PatientAge,-8} | {PatientGender,-8} | {PatientPhone,9:F2} | {PatientEmail,-8}| {PatientBloodType,-8}";

        //public void convertDataToString()
        //{
        //    Console.WriteLine($"{PatientId} | {PatientName,-10} | {PatientAge,-8} | {PatientGender,-8} | {PatientPhone,9:F2}| {PatientEmail,-8}| {PatientBloodType,-8}");
        //}
       

    }
}

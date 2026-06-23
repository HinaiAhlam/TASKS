using project01.model;

namespace project01
{
    public class Program

    {


        public static void RegisterPatient(HospitalContext context, bool isAuto)
        {
            context.Patients.AddRange(new List<Patient>()
                 {
                new Patient(1, "Ahmed ", 30, "Male", "99001122", "ahmed@email.com", "O+"),
                new Patient(2, "Ahlam ", 25, "Female", "99003344", "ahlam@email.com", "A-"),
                new Patient(3, "Khalid ", 40, "Male", "99005566", "khalid@email.com", "B+"),
                new Patient(4, "Fatima ", 22, "Female", "99007788", "fatima@email.com", "AB+"),
                new Patient(5, "Omar", 35, "Male", "99009900", "omar@email.com", "O-"),
                new Patient(6, "alzahra", 28, "Female", "99001234", "noura@email.com", "A+"),
                new Patient(7, " Salim", 50, "Male", "99005678", "salim@email.com", "B-"),
                new Patient(8, "Moza", 33, "Female", "99009012", "moza@email.com", "O+")
                     });
            //الرسالة تظهر فقط إذا لم يكن التسجيل تلقائياً (أو العكس 
            if (!isAuto)
            {
                Console.WriteLine("Patients have been registered successfully!");
            }
        }
        //******** 1
        public static void RegisterPatient(HospitalContext context)
        {
            Console.WriteLine("Enter Patient Name:");
            string? name = Console.ReadLine();

            Console.WriteLine("Enter Age:");
            int age = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter Gender:");
            string? gender = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            string? phone = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter Blood Type:");
            string? bloodType = Console.ReadLine();

            context.Patients.Add(new Patient
            {
                PatientName = name,
                PatientAge = age,
                PatientGender = gender,
                PatientPhone = phone,
                PatientEmail = email,
                PatientBloodType = bloodType,
                PatientId = context.Patients.Count + 1
            });
            Console.WriteLine("Patient Added!");

        }







        //******* 2
        public static void AddDoctor(HospitalContext context)

        {
            Console.WriteLine("Enter Doctor Name:");
            string? doctorName = Console.ReadLine();

            Console.WriteLine("Enter Doctor phon number:");
            string? doctorPhone = Console.ReadLine();

            Console.WriteLine("Enter Doctor Specialization:");
            string? doctorSpecialization = Console.ReadLine();

            Console.WriteLine("Enter Doctor Email");
            string? doctorEmail = Console.ReadLine();

            Console.WriteLine("Enter Doctor ConsultationFee");
            decimal consultationFee = decimal.Parse(Console.ReadLine()!);




            int doctorId = (context.Doctors.Count) + 1;


            context.Doctors.Add(
                 new Doctor
                 {
                     doctorName = doctorName,
                     doctorPhone = doctorPhone,
                     doctorSpecialization = doctorSpecialization,
                     doctorEmail = doctorEmail,
                     consultationFee = consultationFee,
                     doctorId = doctorId
                 }

                );

            Console.WriteLine("doctor Added Successfully with ID " + doctorId);
        }






        //******* 3
        public static void ViewPatients(HospitalContext context)

        {
            var patients = context.Patients.OrderBy(p => p.PatientId)
                                           .ToList();
            if (patients.Count == 0)
            {
                Console.WriteLine(" no patients in the list");
                return;
            }

            //if (context.Patients == null || context.Patients.Count == 0)
            //{
            //    Console.WriteLine(" no patients in the list");
            //    return;
            //}
            Console.WriteLine(" *********   patient list   **********");
            patients.ForEach(patient =>

            //foreach (Patient patient in context.Patients)
            {
                Console.WriteLine("ID: " + patient.PatientId);
                Console.WriteLine("Name: " + patient.PatientName);
                Console.WriteLine("Age: " + patient.PatientAge);
                Console.WriteLine("Gender: " + patient.PatientGender);
                Console.WriteLine("Phone: " + patient.PatientPhone);

                Console.WriteLine("----------------");
            });
        }


        //******* 4
        public static void ViewDoctorsBySpecialization(HospitalContext context)
        {
            Console.WriteLine(" =====  Enter Specialization  =====");
            string? Specialization = Console.ReadLine();

            var doctors = context.Doctors
                               .Where(d => (d.doctorSpecialization ?? "").Contains(Specialization ?? ""))
                               .ToList();
            if (doctors.Count == 0)
            {
                Console.WriteLine("No Doctors Found for this specialization.");
                return;
            }

            Console.WriteLine($"--- Doctors specializing in {Specialization} ---");
            doctors.ForEach(d =>
            {
                Console.WriteLine($"Name: {d.doctorName}");
                Console.WriteLine($"Phone: {d.doctorPhone}");


            });
            //bool found = false;
            //foreach
            //    (Doctor doctor in context.Doctors)
            //{

            //    if (doctor.doctorSpecialization == Specialization)
            //    {
            //        found = true;
            //        Console.WriteLine(doctor.doctorName);
            //        Console.WriteLine(doctor.doctorPhone);

            //    }
            //}
            //if (found == false)
            //{
            //    Console.WriteLine("No Doctors Found");
            //}


        }
        //******* 5
        public static void AddAvailableSlot(HospitalContext context)
        {

            Console.WriteLine(" Enter Dector ID :");
            int doctorId = int.Parse(Console.ReadLine()!);

            Doctor? doctor = context.Doctors.FirstOrDefault(d => d.doctorId == doctorId);

            //Doctor doctor = null;
            //foreach (Doctor d in context.Doctors)
            //{
            //    if (d.doctorId == doctorId)
            //    {
            //        doctor = d;
            //        break;
            //    }

            //}
            if (doctor == null)
            {
                Console.WriteLine(" Doctor Is Not Found ! ");
                return;
            }

            Console.WriteLine(" Enter Avalible Date .");
            string? SlotDate = Console.ReadLine();

            Console.WriteLine(" Enter Avalible Time .");
            string? SlotTime = Console.ReadLine();

            AvailableSlot availableSlot = new AvailableSlot
            {
                SlotDate = SlotDate,
                SlotTime = SlotTime,
                IsBooked = false
            };


            //AvailableSlot availableSlot = new AvailableSlot();

            //availableSlot.SlotDate = SlotDate;
            //availableSlot.SlotTime = SlotTime;
            //availableSlot.IsBooked = false;

            doctor.AvailableSlots.Add(availableSlot);

            context.AvailableSlots.Add(availableSlot);

            Console.WriteLine(" Sloot Add Succufully");

        }

        //******** 6
        public static void BookAppointment(HospitalContext context)
        {
            //1
            Console.WriteLine(" Enter Patient ID : ");
            int PatientId = int.Parse(Console.ReadLine()!);

            var patient = context.Patients.FirstOrDefault(p => p.PatientId == PatientId);
            if (patient == null)
            {
                Console.WriteLine($"Patient {PatientId} not found.");
                return;
            }

            //Patient patient = null;
            //foreach (Patient pat in context.Patients)
            //{
            //    if (pat.PatientId == PatientId)
            //    {
            //        patient = pat;
            //        break;
            //    }
            //}


            //2
            Console.WriteLine(" Enter Doctor ID : ");
            int doctorId = int.Parse(Console.ReadLine()!);

            var doctor = context.Doctors.FirstOrDefault(d => d.doctorId == doctorId);
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found!");
                return;
            }





            //Doctor doctor = null;
            //foreach (Doctor doc in context.Doctors)
            //{
            //    if (doc.doctorId == doctorId)
            //    {
            //        doctor = doc;
            //        break;
            //    }
            //}

            //if (doctor == null)
            //{
            //    Console.WriteLine(" Doctor Is Not Found !");
            //    return;
            //}

            //3
            var availableSlot = doctor.AvailableSlots.Where(s => s.IsBooked == false)
                                                     .ToList();


            bool hasSlots = availableSlot.Any();

            if (hasSlots)
            {
                Console.WriteLine(" Available Slots:  ");
                availableSlot.ForEach(s => Console.WriteLine($"ID: {s.SlotId} | Time: {s.SlotTime}"));
                //foreach (AvailableSlot slot in doctor.AvailableSlots)
            }
            else
            {
                Console.WriteLine(" No available slots for this doctor.");
                return;
            }
            //if (slot.IsBooked == false)
            //{
            //        Console.WriteLine(" No available slots for this doctor.");
            //    }


            //4
            Console.WriteLine(" Enter Slot ID : ");
            int dSlotId = int.Parse(Console.ReadLine()!);

            var selectedslot = availableSlot.FirstOrDefault(s => s.SlotId == dSlotId);

            if (selectedslot == null)
            {
                Console.WriteLine("  Slot Not Avalible ! ");
                return;
            }

            //AvailableSlot selectedslot = null;

            //foreach (AvailableSlot slot in doctor.AvailableSlots)
            //{
            //    if (slot.IsBooked == false)
            //    {
            //        selectedslot = slot;
            //        break;
            //    }

            //}
            //if (selectedslot.IsBooked == true)

            //{
            //    Console.WriteLine("  Slot Not Avalible ! ");
            //    return;

            //}


            //5

            //Appointment appointment = new Appointment();
            //appointment.PatientId = patient.PatientId;
            //appointment.DoctorId = doctor.doctorId;
            //appointment.SlotId = selectedslot.SlotId;
            //appointment.AppointmentDate = selectedslot.SlotDate;
            //appointment.AppointmentTime = selectedslot.SlotTime;
            //appointment.Status = " Booked";
            Appointment appointment = new Appointment
            {
                PatientId = patient.PatientId,
                DoctorId = doctor.doctorId,
                SlotId = selectedslot.SlotId,
                AppointmentDate = selectedslot.SlotDate,
                AppointmentTime = selectedslot.SlotTime,
                Status = " Booked"

            };
            context.Appointments.Add(appointment);

            selectedslot.IsBooked = true;

            Console.WriteLine(" Appointment booked successfully .");

        }



        //****** 7
        public static void CancelAppointment(HospitalContext context)

        {
            Console.WriteLine(" Enter Appointment ID :  ");
            int AppointmentId = int.Parse(Console.ReadLine()!);


            var appoinment = context.Appointments.FirstOrDefault(a => a.AppointmentId == AppointmentId);
            if (appoinment != null)
            {
                //Appointment appointment = null;

                //foreach (Appointment app in context.Appointments)
                //{
                //    if (app.AppointmentId == AppointmentId)
                //    {
                //        appointment = app;
                //        return;
                //    }
                //}

                if (appoinment == null)
                {
                    Console.WriteLine("Appointment not found");
                    return;
                }

                if (appoinment.Status == "Cancelled")
                {
                    Console.WriteLine("Appointment already cancelled");
                    return;

                }

                appoinment.Status = "Cancelled";


                var doctor = context.Doctors.FirstOrDefault(d => d.doctorId == appoinment.DoctorId);
                if (doctor != null)
                {
                    var slot = doctor.AvailableSlots.FirstOrDefault(s => s.SlotId == appoinment.SlotId);
                    if (slot != null)
                    {
                        slot.IsBooked = false;
                    }
                }
                //foreach (Doctor doctor in context.Doctors)
                //{

                //    if (doctor.doctorId == appoinment.DoctorId)

                //    {
                //        foreach (AvailableSlot slot in doctor.AvailableSlots)
                //        {
                //            if (slot.SlotId == appoinment.SlotId)
                //            {
                //                slot.IsBooked = false;
                //                break;
                //            }

                //        }

                //    }

                //}
                Console.WriteLine("Appointment cancelled successfully");
            }
        }


        //******* 8
        public static void CreateMedicalRecord(HospitalContext context)


        {
            Console.WriteLine("  Enter Appointment ID: ");
            int AppointmentId = int.Parse(Console.ReadLine()!);
            var appointment = context.Appointments.FirstOrDefault(a => a.AppointmentId == AppointmentId);

            //Appointment appointment = null;


            //foreach (Appointment appo in context.Appointments)
            //{
            //    if (appo.AppointmentId == AppointmentId)
            //    {
            //        appointment = appo;
            //        return;
            //    }

            //}

            if (appointment == null)
            {
                Console.WriteLine("Appointment not found");
                return;
            }

            Console.WriteLine("  Enter diagnosis");
            string? diagnosis = Console.ReadLine();


            Console.WriteLine("  Enter Prescription");
            string? Prescription = Console.ReadLine();



            var doctor = context.Doctors.FirstOrDefault(d => d.doctorId == appointment.DoctorId);

            //Doctor doctor = null;


            //foreach (Doctor d in context.Doctors)
            //{
            //    if (d.doctorId == appointment.DoctorId)
            //    {
            //        doctor = d;
            //        break;

            //    }
            //}


            if (doctor == null)
            {
                Console.WriteLine("Doctor not found");
                return;
            }


            MedicalRecord record = new MedicalRecord
            {
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentId = appointment.AppointmentId,
                Diagnosis = diagnosis,
                Prescription = Prescription,
                VisitDate = appointment.AppointmentDate,
                VisitFee = doctor.consultationFee
            };

            //MedicalRecord record = new MedicalRecord();
            //record.PatientId = appointment.PatientId;
            //record.DoctorId = appointment.DoctorId;
            //record.AppointmentId = appointment.AppointmentId;
            //record.Diagnosis = diagnosis;
            //record.Prescription = Prescription;
            //record.VisitDate = appointment.AppointmentDate;
            //record.VisitFee = doctor.consultationFee;



            context.MedicalRecords.Add(record);

            appointment.Status = "Completed";


            Console.WriteLine("Medical record created successfully");


        }



        //******** 9
        public static void PatientMedicalHistory(HospitalContext context)


        {

            Console.Write("Enter Patient ID: ");
            int searchId = int.Parse(Console.ReadLine()!);
            var patient = context.Patients.FirstOrDefault(p => p.PatientId == searchId);

            //Patient foundPatient = null;
            //foreach (var p in context.Patients)
            //{
            //    if (p.PatientId == searchId)
            //    {
            //        foundPatient = p;
            //        break;
            //    }
            //}

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            if (!patient.MedicalRecords.Any())
            {
                Console.WriteLine("No records yet for this patient.");
            }
            else
            {
                //decimal totalCost = 0;
                Console.WriteLine($"--- Medical History for {patient.PatientName} ---");

                patient.MedicalRecords.ForEach(record => Console.WriteLine
                ($"Date: {record.VisitDate}," +
                $" Diagnosis: {record.Diagnosis}," +
                $" Cost: ${record.VisitFee}"
                ));

                decimal totalcost = patient.MedicalRecords.Sum(r => r.VisitFee);

                Console.WriteLine($"Total Combined Cost: ${totalcost}");

                //    foreach (var record in foundPatient.MedicalRecords)
                //    {
                //        Console.WriteLine($"Date: {record.VisitDate}, Diagnosis: {record.Diagnosis}, Cost: ${record.VisitFee}");
                //        totalCost += record.VisitFee;
                //    }
                //    Console.WriteLine($"Total Combined Cost: ${totalCost}");
                //}



            }
        }
        //******* 10
        public static void DisplayDoctorPerformanceSummary(HospitalContext context)
        {
            //if (context.Appointments == null || context.Appointments.Count == 0)
            if (context.Appointments == null || !context.Appointments.Any())

            {
                Console.WriteLine("No appointments have been recorded yet.");
                return;
            }

            Console.WriteLine("\n--- Doctor Performance Summary ---");
            var summaryList = context.Doctors.Select(Doctor =>
            {
                var doctorAppoinments = context.Appointments.Where(a => a.DoctorId == Doctor.doctorId)
                                                            .ToList();
                return new
                {
                    Name = Doctor.doctorName,
                    completed = doctorAppoinments.Count(a => a.Status == " Completed "),
                    cancelled = doctorAppoinments.Count(a => a.Status == "Cancelled "),
                    Revenue = doctorAppoinments.Where(a => a.Status == "Completed ").Sum(a => Doctor.consultationFee)


                };

            })
                .OrderByDescending(s => s.Revenue)
                .ToList();


            summaryList.ForEach(item =>
              Console.WriteLine($"Doctor: {item.Name} | " +
              $"Revenue: ${item.Revenue} | " +
              $"Completed: {item.completed} | " +
              $"Cancelled: {item.cancelled}")
              );
        }
        //var summaryList = new List<dynamic>();

        //foreach (var doctor in context.Doctors)
        //{
        //    int completed = 0;
        //    int cancelled = 0;
        //    decimal revenue = 0;

        //    foreach (var appointment in context.Appointments)
        //    {
        //        if (appointment.DoctorId == doctor.doctorId)
        //        {
        //            if (appointment.Status == "Completed")
        //            {
        //                completed++;
        //                revenue += doctor.consultationFee;
        //            }
        //            else if (appointment.Status == "Cancelled")
        //            {
        //                cancelled++;
        //            }
        //        }
        //    }

        //    summaryList.Add(new { Name = doctor.doctorName, Completed = completed, Cancelled = cancelled, Revenue = revenue });
        //}

        //for (int i = 0; i < summaryList.Count - 1; i++)
        //{
        //    for (int j = 0; j < summaryList.Count - i - 1; j++)
        //    {
        //        if (summaryList[j].Revenue < summaryList[j + 1].Revenue)
        //        {
        //            var temp = summaryList[j];
        //            summaryList[j] = summaryList[j + 1];
        //            summaryList[j + 1] = temp;
        //        }
        //    }
        //}

        //foreach (var item in summaryList)
        //{
        //    Console.WriteLine($"Doctor: {item.Name} | Revenue: ${item.Revenue} | Completed: {item.Completed} | Cancelled: {item.Cancelled}");
        //}


        public static void Main(string[] args)
        {
            HospitalContext context = new HospitalContext();
            RegisterPatient(context, true);
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n----********************************************************------");
                Console.WriteLine("\n----------------- Hospital System Menu ----------------");
                Console.WriteLine("\n----********************************************************-------");
                Console.WriteLine("\n");
                Console.WriteLine("1. Register Patient .");
                Console.WriteLine("2. Add Doctor .");
                Console.WriteLine("3. View Patients .");
                Console.WriteLine("4. View Doctors by Specialization .");
                Console.WriteLine("5. Add Available Slot .");
                Console.WriteLine("6. Book Appointment .");
                Console.WriteLine("7. Cancel Appointment .");
                Console.WriteLine("8. Create Medical Record .");
                Console.WriteLine("9. Patient Medical History .");
                Console.WriteLine("10. Doctor Performance Summary .");
                Console.WriteLine("0. Exit.");
                Console.Write("\nChoose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": RegisterPatient(context); break;
                    case "2": AddDoctor(context); break;
                    case "3": ViewPatients(context); break;
                    case "4": ViewDoctorsBySpecialization(context); break;
                    case "5": AddAvailableSlot(context); break;
                    case "6": BookAppointment(context); break;
                    case "7": CancelAppointment(context); break;
                    case "8": CreateMedicalRecord(context); break;
                    case "9": PatientMedicalHistory(context); break;
                    case "10": DisplayDoctorPerformanceSummary(context); break;
                    case "0": running = false; break;

                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }
    }

}
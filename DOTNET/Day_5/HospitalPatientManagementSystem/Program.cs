using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        HospitalManager manager = new HospitalManager();

        manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
        manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");

        manager.AddMedicalHistory(1, "BP Medication");
        manager.AddMedicalHistory(2, "Insulin Therapy");

        manager.ScheduleAppointment(1);
        manager.ScheduleAppointment(2);

        Patient nextPatient = manager.ProcessNextAppointment();

        if (nextPatient != null)
        {
            Console.WriteLine(nextPatient.Name);
        }

        List<Patient> diabeticPatients = manager.FindPatientsByCondition("Diabetes");
        Console.WriteLine(diabeticPatients.Count);

        manager.DisplayPendingAppointments();

        manager.DisplayTotalPatients();

        Patient oldest = manager.FindOldestPatient();

        if (oldest != null)
        {
            Console.WriteLine(oldest.Name);
        }

        manager.GroupPatientsByCondition();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class HospitalManager
{
    private Dictionary<int, Patient> _patients;
    private Queue<Patient> _appointmentQueue;

    public HospitalManager()
    {
        _patients = new Dictionary<int, Patient>();
        _appointmentQueue = new Queue<Patient>();
    }

    public void RegisterPatient(int id, string name, int age, string condition)
    {
        if (_patients.ContainsKey(id))
        {
            Console.WriteLine("Patient ID already exists.");
            return;
        }

        Patient patient = new Patient(id, name, age, condition);
        _patients.Add(id, patient);
    }

    public void ScheduleAppointment(int patientId)
    {
        if (_patients.ContainsKey(patientId))
        {
            _appointmentQueue.Enqueue(_patients[patientId]);
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }

    public Patient ProcessNextAppointment()
    {
        if (_appointmentQueue.Count == 0)
            return null;

        return _appointmentQueue.Dequeue();
    }

    public List<Patient> FindPatientsByCondition(string condition)
    {
        return _patients.Values
            .Where(p => p.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public void AddMedicalHistory(int patientId, string history)
    {
        if (_patients.ContainsKey(patientId))
        {
            _patients[patientId].MedicalHistory.Add(history);
        }
    }

    public void DisplayPendingAppointments()
    {
        foreach (Patient patient in _appointmentQueue)
        {
            Console.WriteLine(patient.Name);
        }
    }

    public void DisplayTotalPatients()
    {
        Console.WriteLine(_patients.Count);
    }

    public Patient FindOldestPatient()
    {
        if (_patients.Count == 0)
            return null;

        return _patients.Values.OrderByDescending(p => p.Age).First();
    }

    public void GroupPatientsByCondition()
    {
        var groups = _patients.Values.GroupBy(p => p.Condition);

        foreach (var group in groups)
        {
            Console.WriteLine(group.Key);

            foreach (Patient patient in group)
            {
                Console.WriteLine(patient.Name);
            }
        }
    }
}
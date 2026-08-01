using System;
using System.Collections.Generic;
using System.Linq;

public class PatientManager
{
    private Dictionary<int, Patient> patientLookup = new Dictionary<int, Patient>();

    private SortedDictionary<int, List<Patient>> priorityPatients =
        new SortedDictionary<int, List<Patient>>();

    private SortedList<int, List<Patient>> departmentPatients =
        new SortedList<int, List<Patient>>();

    private List<Patient> admissionOrder = new List<Patient>();

    private Dictionary<string, int> departmentKeys = new Dictionary<string, int>()
    {
        {"Cardiology",1},
        {"Neurology",2},
        {"Orthopedics",3},
        {"Oncology",4},
        {"General",5}
    };

    private int GetPriorityValue(string priority)
    {
        switch (priority.ToLower())
        {
            case "critical":
                return 1;
            case "high":
                return 2;
            case "medium":
                return 3;
            default:
                return 4;
        }
    }

    public void AddPatient()
    {
        Patient p = new Patient();

        Console.Write("Patient Id : ");
        p.Id = int.Parse(Console.ReadLine());

        Console.Write("Name : ");
        p.Name = Console.ReadLine();

        Console.Write("Department : ");
        p.Department = Console.ReadLine();

        Console.Write("Priority(Critical/High/Medium/Low) : ");
        p.Priority = Console.ReadLine();

        Console.Write("Condition Score : ");
        p.ConditionScore = int.Parse(Console.ReadLine());

        p.AdmissionTime = DateTime.Now;

        patientLookup[p.Id] = p;

        int priorityKey = GetPriorityValue(p.Priority);

        if (!priorityPatients.ContainsKey(priorityKey))
            priorityPatients.Add(priorityKey, new List<Patient>());

        priorityPatients[priorityKey].Add(p);

        int deptKey;

        if (!departmentKeys.ContainsKey(p.Department))
        {
            deptKey = departmentKeys.Count + 1;
            departmentKeys.Add(p.Department, deptKey);
        }
        else
        {
            deptKey = departmentKeys[p.Department];
        }

        if (!departmentPatients.ContainsKey(deptKey))
            departmentPatients.Add(deptKey, new List<Patient>());

        departmentPatients[deptKey].Add(p);

        departmentPatients[deptKey] = departmentPatients[deptKey]
            .OrderByDescending(x => x.ConditionScore)
            .ToList();

        admissionOrder.Add(p);

        Console.WriteLine("Patient Added Successfully");
    }

    public void SearchPatient()
    {
        Console.Write("Enter Patient Id : ");
        int id = int.Parse(Console.ReadLine());

        if (patientLookup.ContainsKey(id))
            Console.WriteLine(patientLookup[id]);
        else
            Console.WriteLine("Patient Not Found");
    }

    public void UpdatePriority()
    {
        Console.Write("Patient Id : ");
        int id = int.Parse(Console.ReadLine());

        if (!patientLookup.ContainsKey(id))
        {
            Console.WriteLine("Patient Not Found");
            return;
        }

        Patient patient = patientLookup[id];

        int oldPriority = GetPriorityValue(patient.Priority);

        priorityPatients[oldPriority].Remove(patient);

        Console.Write("New Priority : ");
        patient.Priority = Console.ReadLine();

        int newPriority = GetPriorityValue(patient.Priority);

        if (!priorityPatients.ContainsKey(newPriority))
            priorityPatients.Add(newPriority, new List<Patient>());

        priorityPatients[newPriority].Add(patient);

        Console.WriteLine("Priority Updated");
    }

    public void DisplayPriorityWise()
    {
        foreach (var item in priorityPatients)
        {
            string priority = "";

            switch (item.Key)
            {
                case 1:
                    priority = "Critical";
                    break;
                case 2:
                    priority = "High";
                    break;
                case 3:
                    priority = "Medium";
                    break;
                case 4:
                    priority = "Low";
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(priority);

            foreach (Patient p in item.Value.OrderBy(x => x.AdmissionTime))
                Console.WriteLine(p);
        }
    }

    public void DisplayAdmissionOrder()
    {
        foreach (Patient p in admissionOrder)
            Console.WriteLine(p);
    }

    public void DisplayDepartmentWise()
    {
        foreach (var dept in departmentPatients)
        {
            Console.WriteLine();

            foreach (var d in departmentKeys)
            {
                if (d.Value == dept.Key)
                {
                    Console.WriteLine(d.Key);
                    break;
                }
            }

            foreach (Patient p in dept.Value)
                Console.WriteLine(p);
        }
    }

    public void CriticalCardiologyReport()
    {
        var report = patientLookup.Values
            .Where(x =>
                x.Department.Equals("Cardiology", StringComparison.OrdinalIgnoreCase) &&
                x.Priority.Equals("Critical", StringComparison.OrdinalIgnoreCase) &&
                x.AdmissionTime >= DateTime.Now.AddHours(-24))
            .OrderBy(x => x.AdmissionTime);

        foreach (Patient p in report)
            Console.WriteLine(p);
    }
}
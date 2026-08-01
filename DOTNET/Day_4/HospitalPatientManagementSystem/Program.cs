using System;

class Program
{
    static void Main(string[] args)
    {
        PatientManager manager = new PatientManager();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Search Patient");
            Console.WriteLine("3. Update Priority");
            Console.WriteLine("4. Display Priority Wise");
            Console.WriteLine("5. Display Admission Order");
            Console.WriteLine("6. Display Department Wise");
            Console.WriteLine("7. Critical Cardiology Report");
            Console.WriteLine("8. Exit");

            Console.Write("Enter Choice : ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    manager.AddPatient();
                    break;

                case 2:
                    manager.SearchPatient();
                    break;

                case 3:
                    manager.UpdatePriority();
                    break;

                case 4:
                    manager.DisplayPriorityWise();
                    break;

                case 5:
                    manager.DisplayAdmissionOrder();
                    break;

                case 6:
                    manager.DisplayDepartmentWise();
                    break;

                case 7:
                    manager.CriticalCardiologyReport();
                    break;

                case 8:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
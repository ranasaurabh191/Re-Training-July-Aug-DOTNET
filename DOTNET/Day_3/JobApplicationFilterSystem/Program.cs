using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Job Application Filter System ===");

        Console.Write("Enter Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Experience (Years): ");
        int experience = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Education (Bachelor/Master/PhD): ");
        string education = Console.ReadLine().ToLower();

        Console.Write("Enter Number of Certifications: ");
        int certifications = Convert.ToInt32(Console.ReadLine());

        bool eligible = true;

        if (age < 21 || age > 60)
            eligible = false;

        if (experience < 2)
            eligible = false;

        if (education != "bachelor" && education != "master" && education != "phd")
            eligible = false;

        int score = experience * 10;

        if (education == "master")
            score += 20;
        else if (education == "phd")
            score += 30;

        score += Math.Min(certifications, 3) * 5;

        Console.WriteLine("\n===== RESULT =====");
        Console.WriteLine($"Eligible      : {(eligible ? "Yes" : "No")}");
        Console.WriteLine($"Total Score   : {score}");

        if (!eligible)
            Console.WriteLine("Recommendation: Does Not Meet Minimum Requirements");
        else if (score >= 70)
            Console.WriteLine("Recommendation: Highly Recommended");
        else if (score >= 50)
            Console.WriteLine("Recommendation: Recommended");
        else
            Console.WriteLine("Recommendation: Consider for Interview");
    }
}
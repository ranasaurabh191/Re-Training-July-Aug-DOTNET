using System;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Priority { get; set; }
    public int ConditionScore { get; set; }
    public DateTime AdmissionTime { get; set; }

    public override string ToString()
    {
        return $"{Id} {Name} {Department} {Priority} Score:{ConditionScore} {AdmissionTime}";
    }
}
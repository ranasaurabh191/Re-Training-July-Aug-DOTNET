namespace LogParserSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;

            string log = "2023-10-27 14:30:00 ERROR: Disk full";

            if (LogParser.ParseLogLine(in log, out DateTime timestamp, out LogLevel level, ref counter))
            {
                Console.WriteLine(timestamp);
                Console.WriteLine(level);
                Console.WriteLine(counter);
            }
            else
            {
                Console.WriteLine("Invalid Log");
            }
        }
    }
}
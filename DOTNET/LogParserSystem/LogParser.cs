namespace LogParserSystem
{
    static class LogParser
    {
        public static bool ParseLogLine(in string logLine, out DateTime timestamp, out LogLevel level, ref int counter)
        {
            timestamp = default;
            level = LogLevel.Unknown;

            string[] parts = logLine.Split(' ');

            if (parts.Length < 3)
                return false;

            if (!DateTime.TryParse(parts[0] + " " + parts[1], out timestamp))
                return false;

            string severity = parts[2].Replace(":", "").ToUpper();

            switch (severity)
            {
                case "INFO":
                    level = LogLevel.Info;
                    break;
                case "WARNING":
                    level = LogLevel.Warning;
                    break;
                case "ERROR":
                    level = LogLevel.Error;
                    break;
                default:
                    level = LogLevel.Unknown;
                    break;
            }

            counter++;
            return true;
        }
    }
}
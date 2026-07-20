static class LogLine
{
    public static string Message(string logLine)
    {
        // 1. Find where the log level header ends by looking for the closing bracket or colon
        int colonIndex = logLine.IndexOf(':');
        
        // 2. Extract everything after the colon
        string message = logLine.Substring(colonIndex + 1);
        
        // 3. Remove the extra leading/trailing whitespace and return
        return message.Trim();   
    }

    public static string LogLevel(string logLine)
    {
        int start = logLine.IndexOf('[');
        int end = logLine.IndexOf(']');
        string level = logLine.Substring(start + 1, end - 1);
        return level.ToLower();
    }

    public static string Reformat(string logLine)
    {
        string message = Message(logLine);
        string level = LogLevel(logLine);
        return $"{message} ({level})";
    }
}

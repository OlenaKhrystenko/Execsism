using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        return Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");
    }

    public string[] SplitLogLine(string text)
    {
        return Regex.Split(text, @"<[\^*=-]+>");
    }

    public int CountQuotedPasswords(string lines)
    {
        string pattern = @"""[^""]*?password[^""]*?""";
        
        return Regex.Matches(lines, pattern, RegexOptions.IgnoreCase).Count;
    }

    public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, @"end-of-line\d+", "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        string[] result = new string[lines.Length];
        
        // Matches "password" followed by zero or more word characters (letters, digits, underscores)
        // Wrapped in \b to ensure it marks the *beginning* of a word token
        string pattern = @"\b(password\w+)";

        for (int i = 0; i < lines.Length; i++)
        {
            // Case-insensitive match to handle variations like "passwordsecret" or "password123"
            Match match = Regex.Match(lines[i], pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                // Prefix with the found password token (preserving its original case)
                result[i] = $"{match.Groups[1].Value}: {lines[i]}";
            }
            else
            {
                // Prefix with dashes if no matching password token is found
                result[i] = $"--------: {lines[i]}";
            }
        }

        return result;
    }
}

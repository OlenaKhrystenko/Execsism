using System;
using System.Globalization;
public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        // Pad the left side (name + space) to exactly 30 characters
        string leftSide = $"{studentA} ".PadLeft(30);

        // Pad the right side (space + name) to exactly 30 characters
        string rightSide = $" {studentB}".PadRight(30);

        // Combine them with the heart in the exact center (30 + 1 + 30 = 61 chars)
        return $"{leftSide}♡{rightSide}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        // Trim any leading or trailing spaces from the inputs to preserve ASCII alignment
        string cleanA = studentA.Trim();
        string cleanB = studentB.Trim();

        return $@"     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {cleanA}  +  {cleanB}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        // Define the German culture info
        CultureInfo germanCulture = CultureInfo.GetCultureInfo("de-DE");

        // Format the date as dd.MM.yyyy and the float with two decimal places using German rules
        string formattedDate = start.ToString("d", germanCulture);
        string formattedHours = hours.ToString("N2", germanCulture);

        return $"{studentA} and {studentB} have been dating since {formattedDate} - that's {formattedHours} hours";
    }
}

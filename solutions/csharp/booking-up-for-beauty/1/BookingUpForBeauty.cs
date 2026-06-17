using System.Globalization;
static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription) => DateTime.Parse(appointmentDateDescription);
 
    public static bool HasPassed(DateTime appointmentDate) => DateTime.Now > appointmentDate;
    
    public static bool IsAfternoonAppointment(DateTime appointmentDate) =>(appointmentDate.Hour >= 12) && (appointmentDate.Hour < 18);
    
    public static string Description(DateTime appointmentDate) => 
        $"You have an appointment on {appointmentDate.ToString("G", CultureInfo.CreateSpecificCulture("en-us"))}.";


    public static DateTime AnniversaryDate() => new DateTime(2026,9,15,0,0,0);
}

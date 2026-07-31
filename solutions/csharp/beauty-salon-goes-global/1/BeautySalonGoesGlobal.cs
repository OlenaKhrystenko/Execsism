using System.Runtime.InteropServices;
using System.Globalization;
using System;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime localTime = DateTime.Parse(
            appointmentDateDescription,
            CultureInfo.InvariantCulture
        );
        string locationID = default;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {  
            switch (location)
            {
                    case Location.NewYork:
                    locationID = "Eastern Standard Time";
                    break;

                case Location.London:
                    locationID = "GMT Standard Time";
                    break;

                case Location.Paris:
                    locationID = "W. Europe Standard Time";
                    break;

                default:
                    locationID = "unknown";
                    break;                 
               
            }     
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                    RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            switch (location)
            {
                   case Location.NewYork:
                    locationID = "America/New_York";
                    break;

                case Location.London:
                    locationID = "Europe/London";
                    break;

                case Location.Paris:
                    locationID = "Europe/Paris";
                    break;

                default:
                    locationID = "unknown";
                    break;
            }
        }
        TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById(locationID);
        return TimeZoneInfo.ConvertTimeToUtc(localTime, zone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        TimeSpan alertOffsetDays = TimeSpan.FromDays(1);
        TimeSpan alertOffsetHours = TimeSpan.FromHours(1.75);
        TimeSpan alertOffsetMinutes = TimeSpan.FromMinutes(30);

        DateTime alert = default;
        
        switch (alertLevel)
        {
            case AlertLevel.Early:
                alert = appointment - alertOffsetDays;
                break;

            case AlertLevel.Standard:
                alert = appointment - alertOffsetHours;
                break;

            case AlertLevel.Late:
                alert = appointment - alertOffsetMinutes;
                break;

            default:
                return alert;
        }
        return alert;
        /*
        return alertLevel switch
    {
        AlertLevel.Early    => appointment - TimeSpan.FromDays(1),
        AlertLevel.Standard => appointment - TimeSpan.FromHours(1.75),
        AlertLevel.Late     => appointment - TimeSpan.FromMinutes(30),
        _                   => default
    };
        */
    }

    private static TimeZoneInfo GetTimeZoneInfo(Location location)
    {
        string zoneId = location switch
        {
            Location.London => OperatingSystem.IsWindows() ? "GMT Standard Time" : "Europe/London",
            Location.NewYork => OperatingSystem.IsWindows() ? "Eastern Standard Time" : "America/New_York",
            Location.Paris => OperatingSystem.IsWindows() ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new ArgumentException("Unsupported location")
        };

        return TimeZoneInfo.FindSystemTimeZoneById(zoneId);
    }
    
    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo tz = GetTimeZoneInfo(location);

        bool currentIsDst = tz.IsDaylightSavingTime(dt);

        for (int i = 1; i <= 7; i++)
        {
            DateTime previousDate = dt.AddDays(-i);

            if (tz.IsDaylightSavingTime(previousDate) != currentIsDst)
            {
                return true;
            }
        }
        return false;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        string cultureName = location switch
        {
            Location.London => "en-GB",
            Location.NewYork => "en-US",
            Location.Paris => "fr-FR",
                _ => "en-US"
        };
        CultureInfo culture = CultureInfo.GetCultureInfo(cultureName);
        
        if (DateTime.TryParse(dtStr, culture, DateTimeStyles.None, out DateTime parsedTime))
        {
            return parsedTime;
        }
        return new DateTime(1,1,1);
    }
}

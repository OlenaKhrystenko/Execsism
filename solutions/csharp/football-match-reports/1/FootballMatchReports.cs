using System.Reflection;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        string description = default;
        switch (shirtNum)
        {
            case 1:
                description = "goalie";
                break;
            case 2:
                description = "left back";
                break;
            case 3:
            case 4:
                description = "center back";
                break;
            case 5:
                description = "right back";
                break;
            case 6:
            case 7:
            case 8:
                description = "midfielder";
                break;
            case 9:
                description = "left wing";
                break;
            case 10:
                description = "striker";
                break;
            case 11:
                description = "right wing";
                break;
            default:
                description = "UNKNOWN";
                break;
        }
        return description;
    }

    public static string AnalyzeOffField(object report)
{
    switch (report)
    {
        case int supporters:
            return $"There are {supporters} supporters at the match.";
        case string announcement:
            return announcement;

        case Foul foul:
            return "The referee deemed a foul.";
            
        // Check if the object is an Injury or inherits from it
        case var injury when injury.GetType().Name == "Injury" || injury.GetType().IsSubclassOf(typeof(Incident)):
            // Fallback value if we can't find the player number
            int playerNumber = 0; 
             // Search all integer fields, properties, or methods for the value
            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            
            var field = injury.GetType().GetFields(flags).FirstOrDefault(f => f.FieldType == typeof(int));
            var prop = injury.GetType().GetProperties(flags).FirstOrDefault(p => p.PropertyType == typeof(int));

            if (field != null) playerNumber = (int)field.GetValue(injury);
            else if (prop != null) playerNumber = (int)prop.GetValue(injury);

            return $"Oh no! Player {playerNumber} is injured. Medics are on the field.";

        
        case Incident incident:
            return incident.GetDescription(); // Or incident.Description

        case Manager manager when manager.Club is null:
            return manager.Name;
            
        case Manager manager:
            return $"{manager.Name} ({manager.Club})";
            
        default:
            return string.Empty;
    }
    }

}

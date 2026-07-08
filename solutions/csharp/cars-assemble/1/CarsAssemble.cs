static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if (speed == 0)
        {
            return 0.0 / 100;
        }
        else if (speed >= 1 && speed <= 4)
        {
            return 100.0 / 100;
        }
        else if (speed >= 5 && speed <= 8)
        {
            return 90.0 / 100;

        }
        else if (speed == 9)
        {
            return 80.0 / 100;
        }
        else
        {
            return 77.0 / 100;
            
        }
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return SuccessRate(speed) * speed * 221;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)(ProductionRatePerHour(speed) / 60);
    }
}

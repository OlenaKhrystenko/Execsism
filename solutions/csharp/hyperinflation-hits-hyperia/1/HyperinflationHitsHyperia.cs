public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        long denomination = 0;
        try
        {
            denomination = checked(@base * multiplier);
        }
        catch(OverflowException e)
        {
            return $"*** Too Big ***";
        }
        return $"{denomination}";
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float denomination = checked(@base * multiplier);
        if (float.IsInfinity(denomination))    
        {
            return $"*** Too Big ***";
        }
        return $"{denomination}";
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        decimal denomination = 0m;
        try
        {
            denomination = salaryBase * multiplier;
        }
        catch(OverflowException e)
        {
            return $"*** Much Too Big ***";
        }
        return $"{denomination}";
    }
}

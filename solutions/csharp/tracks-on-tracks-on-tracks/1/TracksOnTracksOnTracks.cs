public static class Languages
{
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        return new List<string>(){"C#", "Clojure", "Elm"};
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language) => languages.Contains(language);
   

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
         if (languages.Count > 0 && languages[0] == "C#")
        {
            return true;
        }

        // Condition 2: The second item on the list is C# and the list contains 2 or 3 languages.
        if ((languages.Count == 2 || languages.Count == 3) && languages[1] == "C#")
        {
            return true;
        }

        return false;                      // Length of 3, second is C#

        /*
        return languages is ["C#", ..]               // Starts with C# (any length)
        or [_, "C#"]                             // Length of 2, second is C#
        or [_, "C#", _];                         // Length of 3, second is C#*/
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        var seen = new HashSet<string>();
    
        foreach (var language in languages)
        {
            if (!seen.Add(language)) return false;
        }
    
        return true;

        /*
        return languages.Count == languages.Distinct().Count();
        */
    }
}

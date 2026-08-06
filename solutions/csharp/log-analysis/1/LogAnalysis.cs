public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string source, string delimiter)
    {
        if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(delimiter))
        {
            return string.Empty;
        }
        
        int index = source.IndexOf(delimiter);

        if (index == -1)
        {
            return string.Empty;
        }

        return source.Substring(index + delimiter.Length);
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string source, string firstDelim, string secondDelim)
    {
        if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(firstDelim) || string.IsNullOrEmpty(secondDelim))
        {
            return string.Empty;
        }

        int firstIndex = source.IndexOf(firstDelim);
        if (firstIndex == -1)
        {
            return string.Empty;
        }

        int startIndex = firstIndex + firstDelim.Length;//where the string actually starts

        int secondIndex = source.IndexOf(secondDelim, startIndex);
        if (secondIndex == -1)
        {
            return string.Empty;
        }

        return source.Substring(startIndex, secondIndex - startIndex);
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string source)
    {
        return source.SubstringAfter(": ");
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string source)
    {
        return source.SubstringBetween("[", "]");
    }
}
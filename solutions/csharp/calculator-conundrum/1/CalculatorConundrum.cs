public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        switch (operation)
        {
                case("+"):
                    return $"{operand1} {operation} {operand2} = {operand1 + operand2}";
                    break;
                case("*"):
                    return $"{operand1} {operation} {operand2} = {operand1 * operand2}";
                    break;
                case("/"):
                    try
                    {
                        return $"{operand1} {operation} {operand2} = {operand1 / operand2}";
                    }
                    catch (DivideByZeroException)
                    {
                        return "Division by zero is not allowed.";
                    }
                    break;
                case(""):
                        throw new ArgumentException();
                        break;
                case (null):
                    throw new ArgumentNullException();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                    break;
        };
    }
}

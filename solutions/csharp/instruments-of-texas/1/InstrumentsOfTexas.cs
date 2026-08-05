public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner)
        : base(message, inner)
    // TODO: complete the definition of the constructor
    {
        Operand1 = operand1;
        Operand2 = operand2;
        message = default;
        inner = default;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x, y);
        }
        catch (CalculationException ex) when (x < 0 && y < 0)
        {
            return $"Multiply failed for negative operands. {ex.InnerException?.Message}";
        }
        catch (CalculationException ex) when (x > 0 || y > 0)
        {
            return $"Multiply failed for mixed or positive operands. {ex.InnerException?.Message}";
        }
        return "Multiply succeeded"; 
    }

    public void Multiply(int x, int y)
    {
        int result = 0;
        try
        {
            checked
            {
                calculator.Multiply(x,y);
            }
        }
        catch (OverflowException ex)
        {
            throw new CalculationException(x, y, "Arithmetic operation resulted in an overflow.", ex);
        }
        
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}

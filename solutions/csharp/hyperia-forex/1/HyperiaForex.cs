public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // TODO: implement equality operators
    public static bool operator ==(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException(nameof(right));    
        }
        return left.amount == right.amount;
    }
    
    public static bool operator !=(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException(nameof(right));    
        }
        return left.amount != right.amount;
    }
    
    public override bool Equals(object obj)
    {
        if (obj is CurrencyAmount other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(amount, currency);
    }

    // TODO: implement comparison operators
     public static bool operator >(CurrencyAmount left, CurrencyAmount right)
     {
         if (left.currency != right.currency)
         {
             throw new ArgumentException(nameof(right));
         }
         return left.amount > right.amount;
     }

    public static bool operator <(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException(nameof(right));
        }
        return left.amount < right.amount;
    }

    // TODO: implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException(nameof(right));
        }
        return new CurrencyAmount(left.amount + right.amount, left.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException(nameof(right));
        }
        return new CurrencyAmount(left.amount - right.amount, left.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException(nameof(right));
        }
        return new CurrencyAmount(left.amount * right.amount, left.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException(nameof(right));
        }
        if (right.amount == 0)
        {
            throw new DivideByZeroException();
        }
        return new CurrencyAmount(left.amount / right.amount, left.currency);
    }
    // TODO: implement type conversion operators
    public static implicit operator decimal(CurrencyAmount currencyAmount)
    {
        return currencyAmount.amount;
    }

    public static explicit operator double(CurrencyAmount currencyAmount)
    {
        return (double)currencyAmount.amount;
    }
}

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object obj)
    {
        if (obj is FacialFeatures other)
        {
            return (this.EyeColor == other.EyeColor) && (this.PhiltrumWidth == other.PhiltrumWidth);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }

    public static bool operator ==(FacialFeatures left, FacialFeatures right)
    {
        if (left is null)
        {
            return right is null;
        }
        return left == right;
    }

    public static bool operator !=(FacialFeatures left, FacialFeatures right)
    {
        return !(left == right);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object obj)
    {
        if (obj is Identity other)
        {
            return (this.Email == other.Email) && 
            (this.FacialFeatures is null ? other.FacialFeatures is null :         this.FacialFeatures.Equals(other.FacialFeatures));
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }

    public static bool operator ==(Identity left, Identity right)
    {
        if(left is null)
        {
            return right is null;
        }
        return left == right;
    }

    public static bool operator !=(Identity left, Identity right)
    {
        return !(left == right);
    }
}

public class Authenticator
{
    private HashSet<Identity> regId =  new HashSet<Identity>();
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        var adminF = new FacialFeatures("green", 0.9m);
        var admin = new Identity("admin@exerc.ism", adminF);

        return identity.Equals(admin);
    }

    public bool Register(Identity identity)
    {
        if (IsRegistered(identity)) return false;
        else
        {
            regId.Add(identity);
            return true;
        }
    }

    public bool IsRegistered(Identity identity)
    {
        foreach (Identity id in regId)
        {
            if (id.Equals(identity)) return true;
        }
        return false;
    }

    public static bool AreSameObject(Identity identityA, Identity identityB) => Object.ReferenceEquals(identityA, identityB);
  
}

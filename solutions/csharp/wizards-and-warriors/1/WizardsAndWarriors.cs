abstract class Character
{
    protected Character(string characterType)
    {
        
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {this.GetType().Name}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;

}

class Wizard : Character
{
    public bool IsSpellPrepared{get; private set;}
    
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target) => IsSpellPrepared == true ? 12 : 3;

    public void PrepareSpell() => IsSpellPrepared = true;

    public override bool Vulnerable() => IsSpellPrepared == true ? false : true;
 
}

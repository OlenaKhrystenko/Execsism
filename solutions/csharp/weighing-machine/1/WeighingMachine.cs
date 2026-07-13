class WeighingMachine
{
    // TODO: define the 'Precision' property

    public int Precision {get;}

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    // TODO: define the 'Weight' property
    private double _weight;
    public double Weight 
    {
        get => _weight;

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            _weight = value;
        }
    }

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment {get; set;} = 5;

    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight
    {
        get
        {
            double netWeight = Weight - TareAdjustment;
            return $"{netWeight.ToString($"F{Precision}")} kg";
        }
    }
    
}
 
// TODO implement the IRemoteControlCar interface
public interface IRemoteControlCar 
{
    int DistanceTravelled { get; }
    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(ProductionRemoteControlCar other)
    {
        if (other == null) return 1;
        return this.NumberOfVictories.CompareTo(other.NumberOfVictories);
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        return prc1?.CompareTo(prc2) >= 0 || prc2 == null
        ? new List<ProductionRemoteControlCar> { prc2, prc1 }
        : new List<ProductionRemoteControlCar> { prc1, prc2 };
/*        List<ProductionRemoteControlCar> rankedList = new();

// Handle null cases safely
    if (prc1 == null && prc2 == null)
    {
        return rankedList; // Or add both as null, depending on exact requirements
    }
    if (prc1 == null)
    {
        rankedList.Add(prc2);
        rankedList.Add(prc1); // null goes to the end
        return rankedList;
    }
    if (prc2 == null)
    {
        rankedList.Add(prc1);
        rankedList.Add(prc2); // null goes to the end
        return rankedList;
    }
        
        if (prc1.CompareTo(prc2) >= 0)
        {
            rankedList.Add(prc2);
            rankedList.Add(prc1);
        }
        else
        {
            rankedList.Add(prc1);
            rankedList.Add(prc2);
        }
        return rankedList;*/
    }
}

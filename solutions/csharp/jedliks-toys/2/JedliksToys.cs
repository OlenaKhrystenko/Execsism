class RemoteControlCar
{
    private double distance;
    private double battery;

    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {distance} meters";

    public string BatteryDisplay()
    {
        double remainingBattery = 100 - distance * battery / 20;
        if (remainingBattery == 0)
        {
            return "Battery empty";
        }
        else
        {
            return $"Battery at {remainingBattery}%";
        }
    }

    public void Drive()
    {
        if (BatteryDisplay() == "Battery empty") return;
        distance += 20;
        DistanceDisplay();
        battery = 1;
        BatteryDisplay();  
    }
}

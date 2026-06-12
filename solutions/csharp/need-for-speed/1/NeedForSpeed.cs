class RemoteControlCar
{
    private int speed;
    private int batteryDrain;
    private int distanceDriven;
    private int remainingBattery = 100;
    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => remainingBattery < batteryDrain;

    public int DistanceDriven() => distanceDriven;

    public void Drive()
    {        
        if (!BatteryDrained())
        {
            distanceDriven += speed;    
            remainingBattery -= batteryDrain;
        }  
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50,4);
 
}

class RaceTrack
{
    private int distance;
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();    
        }          
        return car.DistanceDriven() >= distance;
    }
}

public abstract class Ammunition : IAmmunition
{
    private const int WEAR_LEVEL_MULTIPLIER = 100;

    public Ammunition()
    {
        WearLevel = WEAR_LEVEL_MULTIPLIER * Weight;
    }

    public string Name => this.GetType().Name;

    public abstract double Weight { get; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        WearLevel -= wearAmount;
    }
}
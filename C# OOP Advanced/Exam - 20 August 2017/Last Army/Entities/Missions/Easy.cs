public class Easy : Mission
{
    private const double ENDURANCE_REQUIRED = 20;
    private const int WEAR_LEVEL_AMUNITIONS = 30;

    public Easy(double scoreToComplete) 
        : base(scoreToComplete) { }

    public override double EnduranceRequired => ENDURANCE_REQUIRED;

    public override string Name => "Suppression of civil rebellion";

    public override double WearLevelDecrement => WEAR_LEVEL_AMUNITIONS;
}
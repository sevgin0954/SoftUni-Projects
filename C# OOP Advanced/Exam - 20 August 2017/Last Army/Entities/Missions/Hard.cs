public class Hard : Mission
{
    private const double ENDURANCE_REQUIRED = 80;
    private const int WEAR_LEVEL_AMUNITIONS = 70;

    public Hard(double scoreToComplete)
        : base(scoreToComplete) { }

    public override double EnduranceRequired => ENDURANCE_REQUIRED;

    public override string Name => "Disposal of terrorists";

    public override double WearLevelDecrement => WEAR_LEVEL_AMUNITIONS;
}
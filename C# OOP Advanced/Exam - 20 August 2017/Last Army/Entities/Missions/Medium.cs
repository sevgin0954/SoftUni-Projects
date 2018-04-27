public class Medium : Mission
{
    private const double ENDURANCE_REQUIRED = 50;
    private const int WEAR_LEVEL_AMUNITIONS = 50;

    public Medium(double scoreToComplete)
        : base(scoreToComplete) { }

    public override double EnduranceRequired => ENDURANCE_REQUIRED;

    public override string Name => "Capturing dangerous criminals";

    public override double WearLevelDecrement => WEAR_LEVEL_AMUNITIONS;
}
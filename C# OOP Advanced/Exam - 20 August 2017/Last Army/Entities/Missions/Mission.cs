public abstract class Mission : IMission
{
    protected Mission(double scoreToComplete)
    {
        ScoreToComplete = scoreToComplete;
    }

    public abstract string Name { get; }

    public abstract double EnduranceRequired { get; }

    public double ScoreToComplete { get; private set; }

    public abstract double WearLevelDecrement { get; }
}
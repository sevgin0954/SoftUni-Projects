using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OVERALL_SKILL_MULTIPLIER = 1.5;
    private const int REGENARATION_MULTIPLIER = 10;

    public Ranker(string name, int age, double experience, double endurance) 
        : base(name, age, experience, endurance) { }

    protected override double OverallSkillMiltiplier => OVERALL_SKILL_MULTIPLIER;

    protected override int RegenerationMultiplier => REGENARATION_MULTIPLIER;

    protected override IReadOnlyList<string> WeaponsAllowed => new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "Helmet"
    };
}
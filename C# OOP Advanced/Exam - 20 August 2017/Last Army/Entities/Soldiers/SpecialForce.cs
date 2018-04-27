using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OVERALL_SKILL_MULTIPLIER = 3.5;
    private const int REGENARATION_MULTIPLIER = 30;

    public SpecialForce(string name, int age, double experience, double endurance) 
        : base(name, age, experience, endurance) { }

    protected override double OverallSkillMiltiplier => OVERALL_SKILL_MULTIPLIER;

    protected override int RegenerationMultiplier => REGENARATION_MULTIPLIER;

    protected override IReadOnlyList<string> WeaponsAllowed => new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "RPG",
        "Helmet",
        "Knife",
        "NightVision"
    };
}
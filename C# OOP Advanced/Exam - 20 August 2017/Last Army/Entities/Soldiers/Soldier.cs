using System;
using System.Linq;
using System.Collections.Generic;

public abstract class Soldier : ISoldier
{
    private const int MAX_ENDURANCE = 100;

    private double endurance;

    public Soldier(string name, int age, double experience, double endurance)
    {
        Name = name;
        Age = age;
        Experience = experience;
        Endurance = endurance;
        Weapons = new Dictionary<string, IAmmunition>();

        foreach (string weaponName in WeaponsAllowed)
        {
            Weapons[weaponName] = null;
        }
    }
    
    public IDictionary<string, IAmmunition> Weapons { get; }
    
    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get => endurance;
        private set
        {
            endurance = Math.Min(value, MAX_ENDURANCE);
        }
    }

    public double OverallSkill => (Age + Experience) * OverallSkillMiltiplier;

    protected abstract double OverallSkillMiltiplier { get; }

    protected abstract int RegenerationMultiplier { get; }

    public bool ReadyForMission(IMission mission)
    {
        if (Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = Weapons.Values.All(weapon => weapon != null);

        if (hasAllEquipment == false)
        {
            return false;
        }

        return Weapons.Values.All(weapon => weapon.WearLevel > 0);
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (Weapons[weaponName].WearLevel <= 0)
            {
                Weapons[weaponName] = null;
            }
        }
    }

    public void Regenerate()
    {
        Endurance += RegenerationMultiplier + Age;
    }

    public void CompleteMission(IMission mission)
    {
        Experience += mission.EnduranceRequired;
        Endurance -= mission.EnduranceRequired;

        foreach (IAmmunition weapon in Weapons.Values.Where(w => w != null))
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, Name, OverallSkill);
}
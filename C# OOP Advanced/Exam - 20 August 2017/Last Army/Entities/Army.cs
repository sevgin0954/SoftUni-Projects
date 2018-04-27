using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Army : IArmy, IEnumerable
{
    private readonly List<ISoldier> soldiers = new List<ISoldier>();

    public IReadOnlyList<ISoldier> Soldiers
    {
        get => soldiers;
    }

    public void AddSoldier(ISoldier soldier)
    {
        soldiers.Add(soldier);
    }

    public IEnumerator GetEnumerator()
    {
        foreach (ISoldier soldier in soldiers)
        {
            yield return soldier;
        }
    }

    public void RegenerateTeam(string soldierType)
    {
        foreach (ISoldier soldier in Soldiers.Where(s => s.GetType().Name == soldierType))
        {
            soldier.Regenerate();
        }
    }
}
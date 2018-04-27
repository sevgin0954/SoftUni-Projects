using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private readonly Dictionary<string, int> amunitionCount = new Dictionary<string, int>();

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        AmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        bool isEquipped = true;

        List<string> missingWeapons = soldier.Weapons.Where(w => w.Value == null || w.Value.WearLevel <= 0).Select(w => w.Key).ToList();
        foreach (string weaponName in missingWeapons)
        {
            if (amunitionCount.ContainsKey(weaponName) && amunitionCount[weaponName] > 0)
            {
                soldier.Weapons[weaponName] = ammunitionFactory.CreateAmmunition(weaponName);
                amunitionCount[weaponName]--;
            }
            else
            {
                isEquipped = false;
            }
        }

        return isEquipped;
    }

    public void AddAmmunitions(IAmmunition ammunition, int count)
    {
        if (amunitionCount.ContainsKey(ammunition.Name) == false)
        {
            amunitionCount[ammunition.Name] = count;
        }
        else
        {
            amunitionCount[ammunition.Name] += count;
        }
    }
}
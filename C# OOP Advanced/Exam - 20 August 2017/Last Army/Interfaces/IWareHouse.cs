public interface IWareHouse
{
    void EquipArmy(IArmy army);

    bool TryEquipSoldier(ISoldier soldier);

    void AddAmmunitions(IAmmunition ammunition, int count);
}
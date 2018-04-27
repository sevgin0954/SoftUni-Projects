using System.Linq;
using System.Text;

public class GameController
{
    IArmy army;
    IWareHouse weraHouse;
    MissionController missionController;
    IWriter consoleWriter;
    public GameController(IWriter writer)
    {
        consoleWriter = writer;
        army = new Army();
        weraHouse = new WareHouse();
        missionController = new MissionController(army, weraHouse);
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0] == "Soldier")
        {
            if (data.Length == 6)
            {
                SoldierFactory soldiersFactory = new SoldierFactory();

                string soldierType = data[1];
                string name = data[2];
                int age = int.Parse(data[3]);
                double experience = double.Parse(data[4]);
                double endurance = double.Parse(data[5]);

                ISoldier soldier = soldiersFactory.CreateSoldier(soldierType, name, age, experience, endurance);

                if (weraHouse.TryEquipSoldier(soldier) == true)
                {
                    AddSoldierToArmy(soldier);
                }
                else
                {
                    string massage = string.Format(OutputMessages.SoldierCannotBeEquiped, soldier.GetType().Name, soldier.Name);
                    throw new System.ArgumentException(massage);
                }
            }
            else if (data[1] == "Regenerate")
            {
                string soldiersType = data[2];

                army.RegenerateTeam(soldiersType);
            }
        }
        else if (data[0].Equals("WareHouse"))
        {
            AmmunitionFactory ammunitionFactory = new AmmunitionFactory();

            string name = data[1];
            int number = int.Parse(data[2]);

            AddAmmunitions(ammunitionFactory.CreateAmmunition(name), number);
        }
        else if (data[0].Equals("Mission"))
        {
            IMissionFactory missionFactory = new MissionFactory();

            string type = data[1];
            double scoreToComplete = double.Parse(data[2]);

            IMission mission = missionFactory.CreateMission(type, scoreToComplete);

            consoleWriter.AppendLine(missionController.PerformMission(mission).Trim());
        }
    }

    public void RequestResult()
    {
        missionController.FailMissionsOnHold();
        consoleWriter.AppendLine(OutputMessages.Result);
        consoleWriter.AppendLine(string.Format(OutputMessages.SuccesfullMissionsCount, missionController.SuccessMissionCounter));
        consoleWriter.AppendLine(string.Format(OutputMessages.FailedMissionCount, missionController.FailedMissionCounter));
        consoleWriter.AppendLine(OutputMessages.Soldiers);

        foreach (ISoldier soldier in army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            consoleWriter.AppendLine(soldier.ToString());
        }
    }

    private void AddAmmunitions(IAmmunition ammunition, int count)
    {
        weraHouse.AddAmmunitions(ammunition, count);
    }

    private void AddSoldierToArmy(ISoldier soldier)
    {
        army.AddSoldier(soldier);
    }
}
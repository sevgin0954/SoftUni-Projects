using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
            : base(data)
        {
            Repository = repository;
        }

        public IRepository Repository
        {
            get => repository;
            set { repository = value; }
        }

        public override string Execute()
        {
            string unitType = Data[1];
            Repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }
    }
}

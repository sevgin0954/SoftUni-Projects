using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository) 
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
            return Repository.Statistics;
        }
    }
}

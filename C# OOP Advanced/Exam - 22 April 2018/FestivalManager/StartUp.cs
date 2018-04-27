namespace FestivalManager
{
	using Core;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class StartUp
	{
		public static void Main(string[] args)
		{
			Stage stage = new Stage();

            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            ISongFactory songFactory = new SongFactory();
			IFestivalController festivalController = new FestivalController(stage, instrumentFactory, performerFactory, songFactory);
			ISetController setController = new SetController(stage);

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

			var engine = new Engine(festivalController, setController, reader, writer);

			engine.Run();
		}
	}
}
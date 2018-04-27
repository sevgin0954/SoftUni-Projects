namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
    using System.Reflection;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";
        private const string Custom = "{0:D2}:{1:D2}";

        private readonly IStage stage;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly IPerformerFactory performerFactory;
        private readonly ISongFactory songFactory;

		public FestivalController(IStage stage, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory, ISongFactory songFactory)
		{
			this.stage = stage;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.songFactory = songFactory;
		}

		public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            string formatedStr = string.Format(Custom, (int)totalFestivalLength.TotalMinutes, totalFestivalLength.Seconds);

			result += ($"Festival length: {formatedStr}") + "\n";

			foreach (var set in this.stage.Sets)
			{
                formatedStr = string.Format(Custom, (int)set.ActualDuration.TotalMinutes, set.ActualDuration.Seconds);

                result += ($"--{set.Name} ({formatedStr}):") + "\n";

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
					}
				}
			}

			return result.ToString();
		}

		public string RegisterSet(string[] args)
		{
            string name = args[0];
            string typeName = args[1];

            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == typeName);

            ISet set = (ISet)Activator.CreateInstance(type, new object[] { name });

            stage.AddSet(set);

            return $"Registered {typeName} set";
		}

		public string SignUpPerformer(string[] args)
		{
			string name = args[0];
			int age = int.Parse(args[1]);

			string[] instrumenti = args.Skip(2).ToArray();

			IInstrument[] instruments = instrumenti
				.Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			IPerformer performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in instruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            string name = args[0];
            TimeSpan timeSpan = TimeSpan.ParseExact(args[1], TimeFormat, CultureInfo.InvariantCulture);

            ISong song = songFactory.CreateSong(name, timeSpan);

            stage.AddSong(song);

            return $"Registered song {name} ({song.Duration.ToString(TimeFormat)})";
		}

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (this.stage.HasSet(setName) == false)
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (this.stage.HasSong(songName) == false)
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration.ToString(TimeFormat)}) to {setName}";
        }

		public string AddPerformerToSet(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

            if (this.stage.HasPerformer(performerName) == false)
			{
				throw new InvalidOperationException("Invalid performer provided");
			}

			if (this.stage.HasSet(setName) == false)
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			var performer = this.stage.GetPerformer(performerName);
			var set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

			return $"Added {performerName} to {setName}";
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
    }
}
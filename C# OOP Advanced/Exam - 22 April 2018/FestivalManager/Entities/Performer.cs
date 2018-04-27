namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Performer : IPerformer
	{
		private readonly List<IInstrument> instruments = new List<IInstrument>();

		public Performer(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public string Name { get; }

		public int Age { get; }

		public IReadOnlyCollection<IInstrument> Instruments => this.instruments;

		public void AddInstrument(IInstrument instrument)
		{
			this.instruments.Add(instrument);
		}

        public override string ToString()
        {
            return this.Name;
        }
    }
}

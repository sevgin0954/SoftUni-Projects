namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		private readonly List<ISet> sets = new List<ISet>();
		private readonly List<ISong> songs = new List<ISong>();
		private readonly List<IPerformer> performers = new List<IPerformer>();

        public IReadOnlyCollection<ISet> Sets => sets;

        public IReadOnlyCollection<ISong> Songs => songs;

        public IReadOnlyCollection<IPerformer> Performers => performers;

        public void AddPerformer(IPerformer performer)
        {
            performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = performers.First(p => p.Name == name);

            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = sets.First(s => s.Name == name);

            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = songs.First(s => s.Name == name);

            return song;
        }

        public bool HasPerformer(string name)
        {
            return performers.Any(p => p.Name == name);
        }

        public bool HasSet(string name)
        {
            return sets.Any(s => s.Name == name);
        }

        public bool HasSong(string name)
        {
            return songs.Any(s => s.Name == name);
        }
    }
}

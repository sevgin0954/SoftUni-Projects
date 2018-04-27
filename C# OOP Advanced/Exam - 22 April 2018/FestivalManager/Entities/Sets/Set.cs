using FestivalManager.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FestivalManager.Entities.Sets
{
    public abstract class Set : ISet
    {
        private List<IPerformer> performers = new List<IPerformer>();

        private List<ISong> songs = new List<ISong>();

        protected Set(string name)
        {
            Name = name;
        }
        public string Name { get; }

        public virtual TimeSpan MaxDuration { get; }

        public TimeSpan ActualDuration => TimeSpan.FromTicks(Songs.Sum(s => s.Duration.Ticks));

        public IReadOnlyCollection<IPerformer> Performers
        {
            get => performers;
        }

        public IReadOnlyCollection<ISong> Songs
        {
            get => songs;
        }

        public void AddPerformer(IPerformer performer)
        {
            performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            if (song.Duration + ActualDuration > MaxDuration)
            {
                throw new InvalidOperationException("Song is over the set limit!");
            }

            songs.Add(song);
        }

        public bool CanPerform()
        {
            if (Songs.Count >= 1 && Performers.Count >= 1 && Performers.All(p => p.Instruments.Any(i => i.IsBroken == false)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Join(", ", this.Performers));

            foreach (var song in this.Songs)
            {
                sb.AppendLine($"-- {song}");
            }

            var result = sb.ToString();
            return result;
        }
    }
}

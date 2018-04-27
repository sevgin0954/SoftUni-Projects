using System;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        public Long(string name) 
            : base(name)
        {
        }

        public override TimeSpan MaxDuration => TimeSpan.FromMinutes(60);
    }
}

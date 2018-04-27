namespace FestivalManager.Entities.Sets
{
	using System;

    public class Short : Set
    {
        public Short(string name) 
            : base(name)
        {
        }

        public override TimeSpan MaxDuration => TimeSpan.FromMinutes(15);
    }
}
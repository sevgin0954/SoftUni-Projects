namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
        public Medium(string name) 
            : base(name)
        {
        }

        public override TimeSpan MaxDuration => TimeSpan.FromMinutes(40);
    }
}
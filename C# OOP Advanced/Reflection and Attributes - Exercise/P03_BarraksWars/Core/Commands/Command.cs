using _03BarracksFactory.Contracts;
using System;

namespace P03_BarraksWars.Core.Commands
{
    abstract class Command : ICommand
    {
        private string[] data;

        public Command(string[] data)
        {
            Data = data;
        }

        protected string[] Data
        {
            get => data;
            set { data = value; }
        }

        public abstract string Execute();
    }
}

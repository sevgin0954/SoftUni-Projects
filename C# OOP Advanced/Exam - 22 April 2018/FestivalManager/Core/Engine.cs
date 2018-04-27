
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using Contracts;
	using Controllers.Contracts;
	using IO.Contracts;

	public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

        public Engine(IFestivalController festivalController, ISetController setController, IReader reader, IWriter writer)
        {
            FestivalCоntroller = festivalController;
            SetCоntroller = setController;
            this.reader = reader;
            this.writer = writer;
        }

		protected IFestivalController FestivalCоntroller { get; private set; }
		protected ISetController SetCоntroller { get; private set; }

		public void Run()
		{
			while (true)
			{
				var input = reader.ReadLine();

				if (input == "END")
                {
                    break;
                }

				try
				{
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (System.Reflection.TargetInvocationException ex)
				{
					this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
				}
			}

			var end = this.FestivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			string[] args = input.Split();

			var commandType = args[0];
			var parameters = args.Skip(1).ToArray();

			if (commandType == "LetsRock")
			{
				var setovete = this.SetCоntroller.PerformSets();
				return setovete;
			}

			var festivalcontrolfunction = this.FestivalCоntroller.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == commandType);

			string result;

			try
			{
				result = (string)festivalcontrolfunction.Invoke(this.FestivalCоntroller, new object[] { parameters });
			}
            catch (System.Reflection.TargetInvocationException ioe)
            {
                result = "ERROR: " + ioe.InnerException.Message;
            }
			catch (ArgumentException ae)
			{
                result = ae.Message;
			}

			return result;
		}
    }
}
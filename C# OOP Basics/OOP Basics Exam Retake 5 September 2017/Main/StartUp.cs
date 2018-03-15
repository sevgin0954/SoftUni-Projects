using System;
using System.Collections.Generic;

using System.Linq;

class StartUp
{
    static void Main()
    {
        DraftManager draftManager = new DraftManager();

        while (true)
        {
            List<string> input = new List<string>(Console.ReadLine().Split());
            string command = input[0];
            input.RemoveAt(0);

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(input));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(input));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(draftManager.Mode(input));
                    break;
                case "Check":
                    Console.WriteLine(draftManager.Check(input));
                    break;
                case "Shutdown":
                    Console.WriteLine(draftManager.ShutDown());
                    return;
            }
        }
    }
}

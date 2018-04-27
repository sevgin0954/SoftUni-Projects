using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        string createCommand = Console.ReadLine();
        string[] elements = Array.Empty<string>();
        if (createCommand.Length > 7)
        {
            elements = createCommand.Substring(7, createCommand.Length - 7).Split();
        }
        
        List<string> collection = new List<string>(elements);

        ListyIterator<string> listyIterator = new ListyIterator<string>(collection);

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "END")
            {
                break;
            }

            try
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "PrintAll":
                        Print(listyIterator);
                        Console.WriteLine();
                        break;
                }
            }
            catch (InvalidOperationException nre)
            {
                Console.WriteLine(nre.Message);
            }
        }
    }

    static void Print(ListyIterator<string> listyIterator)
    {
        foreach (var li in listyIterator)
        {
            Console.Write(li + " ");
        }
    }
}

using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
            DungeonMaster dungeonMaster = new DungeonMaster();
            bool isGameOver = false;

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input) || isGameOver)
                    {
                        break;
                    }

                    string[] arguments = input.Split();
                    string command = arguments[0];
                    arguments = arguments.Skip(1).ToArray();

                    switch (command)
                    {
                        case "JoinParty":
                            Console.WriteLine(dungeonMaster.JoinParty(arguments));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(dungeonMaster.AddItemToPool(arguments));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(dungeonMaster.PickUpItem(arguments));
                            break;
                        case "UseItem":
                            Console.WriteLine(dungeonMaster.UseItem(arguments));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(dungeonMaster.UseItemOn(arguments));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(dungeonMaster.GiveCharacterItem(arguments));
                            break;
                        case "GetStats":
                            Console.WriteLine(dungeonMaster.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(dungeonMaster.Attack(arguments));
                            break;
                        case "Heal":
                            Console.WriteLine(dungeonMaster.Heal(arguments));
                            break;
                        case "EndTurn":
                            Console.WriteLine(dungeonMaster.EndTurn(arguments));
                            break;
                        case "IsGameOver":
                            if (dungeonMaster.IsGameOver())
                            {
                                isGameOver = true;
                                Console.WriteLine(true);
                            }
                            else
                            {
                                Console.WriteLine(false);
                            }
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Parameter Error: " + ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("Invalid Operation: " + ioe.Message);
                }
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
		}
	}
}
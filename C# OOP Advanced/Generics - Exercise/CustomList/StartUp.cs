using System;

class StartUp
{
    static void Main()
    {
        CustomList<string> customList = new CustomList<string>();

        while (true)
        {
            string[] command = Console.ReadLine().Split();

            switch (command[0])
            {
                case "Add":
                    customList.Add(command[1]);
                    break;
                case "Remove":
                    int index = int.Parse(command[1]);
                    customList.Remove(index);
                    break;
                case "Contains":
                    Console.WriteLine(customList.Contains(command[1]));
                    break;
                case "Swap":
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);
                    customList.Swap(index1, index2);
                    break;
                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(command[1]));
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());
                    break;
                case "Print":
                    Print(customList);
                    break;
                case "Sort":
                    customList.Sort();
                    break;
                case "END":
                    return;
            }
        }        
    }

    static void Print(CustomList<string> customList)
    {
        for (int a = 0; a < customList.Length; a++)
        {
            Console.WriteLine(customList[a]);
        }
    }
}

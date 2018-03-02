using System;

class StartUp
{
    static void Main()
    {
        string[] numbersToCall = Console.ReadLine().Split();
        string[] addressesToBrowse = Console.ReadLine().Split();
        Smartphone smartphone = new Smartphone();

        for (int a = 0; a < numbersToCall.Length; a++)
        {
            string number = numbersToCall[a];

            try
            {
                smartphone.Call(number);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        for (int a = 0; a < addressesToBrowse.Length; a++)
        {
            string address = addressesToBrowse[a];

            try
            {
                smartphone.Browse(address);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

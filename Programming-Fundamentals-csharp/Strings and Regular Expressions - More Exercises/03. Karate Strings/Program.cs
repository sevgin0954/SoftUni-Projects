using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        for (int a = 1; a < input.Length - 1; a++)
        {
            if (char.IsDigit(input[a]) && input[a - 1] == '>')
            {
                if (input[a] > 0)
                {
                    int power = 0;
                    int index = a;
                    do
                    {
                        if (char.IsDigit(input[index]) && input[index - 1] == '>')
                        {
                            power += int.Parse(input[index].ToString());
                        }
                        if ((input[index] == '>' && index < input.Length - 1 && char.IsDigit(input[index + 1])) == false)
                        {
                            power--;
                            input = input.Remove(index, 1);
                        }
                        else
                        {
                            index++;
                        }
                    } while (power > 0 && index < input.Length);
                }
            }
        }
        Console.Write(input);
    }
}
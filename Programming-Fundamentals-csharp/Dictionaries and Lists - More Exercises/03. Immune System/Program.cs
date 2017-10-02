using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        long health = long.Parse(Console.ReadLine());
        long maxHealth = health;
        Dictionary<string, long> virusesTimesToDefeat = new Dictionary<string, long>();
        while (true)
        {
            string virusName = Console.ReadLine();
            if (virusName == "end")
            {
                break;
            }
            long asciiCharsSum = 0;
            for (int a = 0; a < virusName.Length; a++)
            {
                asciiCharsSum += virusName[a];
            }
            long virusStrength = (long)(asciiCharsSum / 3.0);
            long timeToDefeatVirus = 0;
            if (virusesTimesToDefeat.ContainsKey(virusName))
            {
                timeToDefeatVirus = (long)(virusesTimesToDefeat[virusName] * virusName.Length / 3.0);
            }
            else
            {
                timeToDefeatVirus = virusStrength * virusName.Length;
                virusesTimesToDefeat[virusName] = virusStrength;
            }
            health -= timeToDefeatVirus;
            Console.WriteLine($"Virus {virusName}: {virusStrength} => {timeToDefeatVirus} seconds");
            if (health < 0)
            {
                Console.WriteLine("Immune System Defeated.");
                return;
            }
            int seconds = (int)timeToDefeatVirus % 60;
            int minutes = (int)timeToDefeatVirus / 60;
            Console.WriteLine($"{virusName} defeated in {minutes}m {seconds}s.");
            Console.WriteLine($"Remaining health: {health}");
            health += (long)(health * 0.2);
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
        Console.Write($"Final Health: {health}");
    }
}
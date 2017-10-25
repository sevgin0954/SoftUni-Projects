using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int maxEnergy = int.Parse(Console.ReadLine());
        Jarvis = ReadJarvisParts();
    }

    static Jarvis ReadJarvisParts()
    {
        Jarvis jarvis = new Jarvis();
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "Assemble!")
            {
                break;
            }
        }
    }
} 

class Jarvis
{
    public Head Head { get; set; }
    public Torso Torso { get; set; }
    public List<Arm> Arms { get; set; }
    public List<Leg> Legs { get; set; }
    
    public void AddHead(Head headInput)
    {
        if (headInput.Energy < Head.Energy)
        {
            Head = headInput;
        }
    }

    public void AddTorso(Torso torsoInput)
    {
        if (torsoInput.Energy < Torso.Energy)
        {
            Torso = torsoInput;
        }
    }

    public void AddArm(Arm armInput)
    {
        if (Arms.Count < 2)
        {
            Arms.Add(armInput);
        }
        else
        {
            for (int a = 0; a < Arms.Count; a++)
            {
                if (armInput.Energy < Arms[a].Energy)
                {
                    Arms.RemoveAt(0);
                    Arms.Add(armInput);
                    break;
                }
            }
        }
    }

    public void AddLeg(Leg legInput)
    {
        if (Legs.Count < 2)
        {
            Legs.Add(legInput);
        }
        else
        {
            for (int a = 0; a < Legs.Count; a++)
            {
                if (legInput.Energy < Legs[a].Energy)
                {
                    Legs.RemoveAt(0);
                    Legs.Add(legInput);
                    break;
                }
            }
        }
    }
}

class Leg
{
    public int Energy { get; set; }
    public int Strength { get; set; }
    public int Speed { get; set; }
}

class Arm
{
    public int Energy { get; set; }
    public int Reach { get; set; }
    public int FingerCount { get; set; }
}

class Torso
{
    public int Energy { get; set; }
    public int CpuSize { get; set; }
    public int Material { get; set; }
}

class Head
{
    public int Energy { get; set; }
    public int Iq { get; set; }
    public int Material { get; set; }
}
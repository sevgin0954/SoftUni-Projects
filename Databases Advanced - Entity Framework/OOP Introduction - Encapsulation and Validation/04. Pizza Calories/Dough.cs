using System;

class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public string FlourType
    {
        get
        {
            return flourType;
        }
        set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    public string BakingTechnique
    {
        get
        {
            return bakingTechnique;
        }
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    public double Weight
    {
        get
        {
            return weight;
        }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public double CalculateCalories()
    {
        double bakingModifier = 0.9;
        if (BakingTechnique.ToLower() == "chewy")
        {
            bakingModifier = 1.1;
        }
        else if (BakingTechnique.ToLower() == "homemade")
        {
            bakingModifier = 1;
        }

        double flourModifier = 1.5;
        if (FlourType.ToLower() == "wholegrain")
        {
            flourModifier = 1;
        }

        return 2 * weight * bakingModifier * flourModifier;
    }
}

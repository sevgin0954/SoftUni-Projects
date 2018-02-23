public static class InputValidator
{
    public static void ValidateMoney(decimal money)
    {
        if (money < 0)
        {
            throw new System.ArgumentException("Money cannot be negative");
        }
    }

    public static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new System.ArgumentException("Name cannot be empty");
        }
    }
}

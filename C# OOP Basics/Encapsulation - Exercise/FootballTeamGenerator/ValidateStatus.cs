public static class ValidateStatus
{
    public static void ValidateData(byte value, string statusName)
    {
        if (value < 0 || value > 100)
        {
            throw new System.ArgumentException($"{statusName} should be between 0 and 100.");
        }
    }
}
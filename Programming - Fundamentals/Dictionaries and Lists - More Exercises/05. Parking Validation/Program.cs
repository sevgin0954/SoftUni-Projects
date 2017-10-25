using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, string> usernamesLicencekeys = new Dictionary<string, string>();
        int n = int.Parse(Console.ReadLine());
        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "unregister")
            {
                if (usernamesLicencekeys.Remove(input[1]))
                {
                    Console.WriteLine($"user {input[1]} unregistered successfully");
                }
                else
                {
                    Console.WriteLine($"ERROR: user {input[1]} not found");
                }
            }
            else if (input[0] == "register")
            {
                string username = input[1];
                string licenseKey = input[2];
                if (usernamesLicencekeys.ContainsKey(username))
                {
                    Console.WriteLine($"ERROR: already registered with plate number {usernamesLicencekeys[username]}");
                    continue;
                }
                if (CheckIsLicenceKeyIsValid(licenseKey) == false)
                {
                    Console.WriteLine($"ERROR: invalid license plate {licenseKey}");
                    continue;
                }
                if (usernamesLicencekeys.ContainsValue(licenseKey))
                {
                    Console.WriteLine($"ERROR: license plate {licenseKey} is busy");
                    continue;
                }
                usernamesLicencekeys[username] = licenseKey;
                Console.WriteLine($"{username} registered {licenseKey} successfully");
            }
        }
        foreach (KeyValuePair<string, string> usernameLicensekey in usernamesLicencekeys)
        {
            Console.WriteLine($"{usernameLicensekey.Key} => {usernameLicensekey.Value}");
        }
    }

    static bool CheckIsLicenceKeyIsValid(string licenceKey)
    {
        if (licenceKey.Length != 8)
        {
            return false;
        }
        int temp = 0;
        for (int a = 0; a <= 1; a++)
        {
            if (licenceKey[a] < 65 || licenceKey[a] > 90)
            {
                return false;
            }
        }
        for (int a = 6; a < 8; a++)
        {
            if (licenceKey[a] < 65 || licenceKey[a] > 90)
            {
                return false;
            }
        }
        string mid = licenceKey.Substring(2, 4);
        for (int a = 0; a < mid.Length; a++)
        {
            string midChar = mid[a].ToString();
            if (int.TryParse(midChar, out temp) == false)
            {
                return false;
            }
        }
        return true;
    }
}
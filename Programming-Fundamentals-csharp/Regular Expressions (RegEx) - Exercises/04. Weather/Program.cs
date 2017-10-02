using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, string[]> citysTempsWeathers = new Dictionary<string, string[]>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                break;
            }
            Regex regx = new Regex(@"([A-Z]{2})(\d+\.\d+)([a-zA-Z]+)(?=\|)");
            if (regx.IsMatch(input) == false)
            {
                continue;
            }
            Match match = regx.Match(input);
            string city = match.Groups[1].Value;
            string temp = match.Groups[2].Value;
            string weather = match.Groups[3].Value;
            if (citysTempsWeathers.ContainsKey(city))
            {
                citysTempsWeathers[city][0] = temp;
                citysTempsWeathers[city][1] = weather;
            }
            else
            {
                citysTempsWeathers[city] = new string[] { temp, weather};
            }
        }
        foreach (KeyValuePair<string, string[]> cityTempWeather in citysTempsWeathers.OrderBy(kvp => kvp.Value[0]))
        {
            Console.WriteLine($"{cityTempWeather.Key} => {double.Parse(cityTempWeather.Value[0]):f2} => {cityTempWeather.Value[1]}");
        }
    }
}
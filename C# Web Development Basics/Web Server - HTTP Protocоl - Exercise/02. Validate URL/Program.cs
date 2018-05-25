using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string regxPattern = @"^" + 
            @"((?<protocol>http|https):)" +
            @"\/{2}" +
            @"(?<host>[\w\d-]+(\.bg|\.com|\.net))" +
            @"(:(?<port>80|447))*" +
            @"(?<path>\/\w*(\.\w+)*)*" +
            @"(\?(?<queryString>[^#]+&*))*" +
            @"(#(?<fragment>.+))*" +
            @"$";

        string[] groupsNames = { "protocol", "host", "port", "path", "queryString", "fragment" };
        
        Match match = Regex.Match(input, regxPattern);
        
        if (match.Success == false)
        {
            Console.WriteLine("Invalid URL");
        }
        else
        {
            foreach (string group in groupsNames)
            {
                string currentGroup = match.Groups[group].Value;
                if (currentGroup == string.Empty)
                {
                    if (group == "port")
                    {
                        string protocol = match.Groups[groupsNames[0]].Value;

                        if (protocol  == "http")
                        {
                            currentGroup = "80";
                        }
                        else if (protocol == "https")
                        {
                            currentGroup = "443";
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine($"{group}: {currentGroup}");
            }
        }
    }
}
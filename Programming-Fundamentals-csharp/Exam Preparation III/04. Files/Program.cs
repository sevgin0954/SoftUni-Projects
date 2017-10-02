using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, long>> rootsFiles = new Dictionary<string, Dictionary<string, long>>();        
        int n = int.Parse(Console.ReadLine());
        for (int a = 0; a < n; a++)
        {
            string fileDir = Console.ReadLine();
            string rootName = fileDir.Substring(0, fileDir.IndexOf('\\'));
            string fileNameSize = fileDir.Substring(fileDir.LastIndexOf('\\') + 1);
            string fileName = fileNameSize.Substring(0, fileNameSize.IndexOf(';'));
            long fileSize = long.Parse(fileNameSize.Substring(fileNameSize.LastIndexOf(';') + 1));
            if (rootsFiles.ContainsKey(rootName) == false)
            {
                rootsFiles[rootName] = new Dictionary<string, long>();
            }
            rootsFiles[rootName][fileName] = fileSize;
        }
        string[] query = Console.ReadLine().Split();
        string extension = query[0];
        string root = query[2];
        bool isExist = false;
        foreach (KeyValuePair<string, Dictionary<string, long>> rootFile in rootsFiles)
        {
            if (rootFile.Key == root)
            {
                foreach (KeyValuePair<string, long> fileSize in rootFile.Value.OrderBy(kvp => -kvp.Value).ThenBy(kvp => kvp.Key))
                {
                    string ext = fileSize.Key.Substring(fileSize.Key.LastIndexOf('.') + 1);
                    if (ext == extension)
                    {
                        Console.WriteLine($"{fileSize.Key} - {fileSize.Value} KB");
                        isExist = true;
                    }
                }
            }
        }
        if (isExist == false)
        {
            Console.Write("No");
        }
    }
}
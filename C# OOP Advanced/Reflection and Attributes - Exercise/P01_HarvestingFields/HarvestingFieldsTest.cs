 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            while (true)
            {
                string accessModifier = Console.ReadLine();

                switch (accessModifier)
                {
                    case "private":
                        FieldInfo[] privateFields = typeof(HarvestingFields)
                            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                            .Where(f => f.IsPrivate)
                            .ToArray();
                        Print(privateFields);
                        break;
                    case "protected":
                        FieldInfo[] protectedFields = typeof(HarvestingFields)
                            .GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                            .Where(f => f.IsFamily)
                            .ToArray();
                        Print(protectedFields);
                        break;
                    case "public":
                        FieldInfo[] publicFields = typeof(HarvestingFields)
                            .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                            .ToArray();
                        Print(publicFields);
                        break;
                    case "all":
                        FieldInfo[] allFields = typeof(HarvestingFields)
                            .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                        Print(allFields);
                        break;
                    case "HARVEST":
                        return;
                }
            }
        }

        public static void Print(FieldInfo[] fields)
        {
            foreach (FieldInfo field in fields)
            {
                string accessModifier = field.Attributes.ToString().ToLower();

                if (accessModifier == "family")
                {
                    accessModifier = "protected";
                }

                Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}

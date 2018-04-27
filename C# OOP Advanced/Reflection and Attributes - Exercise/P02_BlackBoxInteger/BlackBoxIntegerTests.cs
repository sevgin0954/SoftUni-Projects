namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var constructors = typeof(BlackBoxInteger)
                .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            BlackBoxInteger blackBoxInteger = (BlackBoxInteger)constructors[0].Invoke(new object[] { 0 });

            while (true)
            {
                string[] input = Console.ReadLine().Split('_');
                string methodName = input[0];

                if (methodName == "END")
                {
                    break;
                }

                int value = int.Parse(input[1]);

                MethodInfo method = blackBoxInteger
                            .GetType()
                            .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
                method.Invoke(blackBoxInteger, new object[] { value });

                FieldInfo innerValueField = blackBoxInteger
                    .GetType()
                    .GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

                Console.WriteLine(innerValueField.GetValue(blackBoxInteger));
            }
        }
    }
}

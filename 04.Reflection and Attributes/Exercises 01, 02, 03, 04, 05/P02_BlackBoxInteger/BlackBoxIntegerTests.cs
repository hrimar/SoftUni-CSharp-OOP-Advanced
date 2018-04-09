namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests   // Very important!!!
    {
        public static void Main() //100/100
        {
            //var type = typeof(P02_BlackBoxInteger.BlackBoxInteger); // or
            var type = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");

            // Взимаме полето, с което работи класа:
            FieldInfo innerValue = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            // Изваждаме всияки методи на класа:
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

           object instance = (BlackBoxInteger)Activator.CreateInstance(type, true); // иска ,true за private ctor !!!!!!!

            string input;
            while ((input =Console.ReadLine()) != "END")
            {
                var inputArgs = input.Split('_');
                var command = inputArgs[0];
                int number =int.Parse(inputArgs[1]);

                // Вместо да правим switch-case по команда, н авсеки метод с такова име подаваме числото:
                MethodInfo method = methods.First(m => m.Name == command);
                method.Invoke(instance, new object[] { number }); // изпълняваме метода и
                Console.WriteLine(innerValue.GetValue(instance));   // проверяваме ст-ста на полето за резултата

            }
        }
    }
}

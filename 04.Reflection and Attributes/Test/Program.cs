using System;
using System.Reflection;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main()
        {
            Type userType = typeof(User);

            User userInstance = (User)Activator.CreateInstance(userType, 5, "Pesho", 55);

            //Console.WriteLine(userInstance.CalcIdPlusAge());
            FieldInfo[] fields = userType.GetFields();
            FieldInfo field = userType.GetField("city", BindingFlags.Instance | BindingFlags.NonPublic);
           // Console.WriteLine(field.IsFamily);
            // А как се проверява дали е readonly field??????????
            var sb = new StringBuilder("");
            foreach (var f in fields)
            {
                Console.WriteLine(f.Name); // 
                Console.WriteLine(f.FieldType);

            }
        }
    }
}

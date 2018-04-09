namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()   // 100/100
        {
            //var type = typeof(P01_HarvestingFields.HarvestingFields); // or
            Type type = Type.GetType("P01_HarvestingFields.HarvestingFields");

            FieldInfo[] allFields = type.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic); //  | BindingFlags.Static

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
               // Var2 - to use Switch-case
                if (input == "public")
                {
                    var publicOnly = allFields.Where(f => f.IsPublic).ToArray();
                    Print(publicOnly);
                }
                else if (input == "protected")
                {
                    var privateOnly = allFields.Where(f => f.IsFamily).ToArray();
                    Print(privateOnly);
                }
                else if (input == "private")
                {
                    var privateOnly = allFields.Where(f => f.IsPrivate).ToArray();
                    Print(privateOnly);
                }
                else if (input == "all")
                {
                    Print(allFields);
                }
            }
        }

        private static void Print(FieldInfo[] fields)
        {
            foreach (var field in fields)
            {
                // Var.1:
                //var modifier = field.Attributes.ToString().ToLower();

                //if(field.Attributes == FieldAttributes.Family)  // - вместо да сравняваме стрингове-> (modifier == "family")
                //{
                //    modifier = "protected";
                //}

                // Var.2:
                string modifier = null;
                switch (field.Attributes)
                {                    
                    case FieldAttributes.Family:
                        modifier = "protected";
                        break;    
                    case FieldAttributes.Private:
                        modifier = "private";
                        break;                    
                    case FieldAttributes.Public:
                        modifier = "public";
                        break;                    
                }
                Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}

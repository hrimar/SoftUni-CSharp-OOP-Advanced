using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Spy
{

    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        var sb = new StringBuilder();

        Type hackerType = Type.GetType(classToInvestigate);
        //Hacker hackerInstance = (Hacker)Activator.CreateInstance(hackerType); - NO!!!
        var hackerInstance = Activator.CreateInstance(Type.GetType(classToInvestigate)); // YES!!!

        FieldInfo[] allFields = hackerType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        sb.AppendLine($"Class under investigation: {classToInvestigate}");
        foreach (var field in allFields)
        {
            if (fieldsToInvestigate.Contains(field.Name))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(hackerInstance)}");
            }
        }

        return sb.ToString().Trim();
    }
}


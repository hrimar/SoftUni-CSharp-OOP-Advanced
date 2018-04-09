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

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();

        var classType = Type.GetType(className);

        // Var.1:
        //foreach (var field in classType.GetFields())
        //{
        //    sb.AppendLine($"{field.Name} must be private!");
        //}

        //var properties = classType.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        //foreach (var prop in properties)
        //{
        //    if (prop.GetMethod?.IsPrivate == true) // взима get-ерите ако не са null !!!
        //    {
        //        sb.AppendLine($"{prop.GetMethod.Name} have to be public!");
        //    }

        //}
        //foreach (var prop in properties)
        //{
        //    if (prop.SetMethod?.IsPublic == true) // взима set-ерите ако не са null !!!
        //    {
        //        sb.AppendLine($"{prop.SetMethod.Name} have to be private!");
        //    }
        //}
        
        // Var.2:
        var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        var publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        var nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (MethodInfo method in nonPublicMethods.Where(m=>m.Name.StartsWith("get")))
        {            
                sb.AppendLine($"{method.Name} have to be public!");            

        }
        foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }
        return sb.ToString().Trim();
    }
}


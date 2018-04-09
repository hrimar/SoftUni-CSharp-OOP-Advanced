using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Spy
{

    public string CollectGettersAndSetters(string className)
    {
        var sb = new StringBuilder();

        var classType = Type.GetType(className);

        // Var.1:
        //var alMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic |
        //    BindingFlags.Public);
        //foreach (var method in alMethods.Where(m=>m.Name.Contains("get")))
        //{
        //    sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        //}
        //foreach (var method in alMethods.Where(m => m.Name.StartsWith("set")))
        //{
        //    sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        //}

        // Var.2:
        var properties = classType.GetProperties(BindingFlags.Instance |BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var prop in properties)
        {
            if (prop.GetMethod != null) // Getters
            {
                sb.AppendLine($"{prop.GetMethod.Name} will return {prop.GetMethod.ReturnType}");
            }

        }
        foreach (var prop in properties) // Setters
        {
            if (prop.SetMethod != null) // взима set-ерите ако не са null !!!
            {
                sb.AppendLine($"{prop.SetMethod.Name} will set field of {prop.SetMethod.GetParameters().First().ParameterType}");
            }
        }

        return sb.ToString().Trim();
    }

    // Lab.03:
    public string RevealPrivateMethods(string className)
    {
        var sb = new StringBuilder();

        var classType = Type.GetType(className);
        var allPrivateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");
        foreach (var method in allPrivateMethods)
        {
            sb.AppendLine($"{method.Name}");
        }

        return sb.ToString().Trim();
    }

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
        foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
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


using System;
using System.Collections.Generic;
using System.Text;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class TypeAttribute : Attribute
{
    public TypeAttribute(string category)
    {
        this.Type = "Enumeration";
        ParseEnum(category);
        this.Description = $"Provides {category.ToLower()} constants for a Card class.";
    }

    private void ParseEnum(string category)
    {
        bool isValidType = Enum.TryParse(typeof(Category), category, out object outType);
        if (!isValidType)
        {
            throw new ArgumentException("Invalid type!");
        }
        this.Category = (Category)outType;
    }

    public string Type { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"Type = {this.Type}, Description = {this.Description}";
    }
}


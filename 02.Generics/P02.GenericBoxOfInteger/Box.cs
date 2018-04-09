using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
   // private List<T> items;
    private T value;

    public Box(T value)
    {
        // this.items = new List<T>();
        this.value = value;
    }

    public override string ToString()
    {
        return $"{this.value.GetType().FullName}: {this.value}";
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private readonly List<T> items; // readonly ПОЛЕ, изразяващо същността на класа!!!

    public int Count => this.items.Count;


    public Box()
    {
        this.items = new List<T>();
    }
    
    public void Add(T item)
    {
        this.items.Add(item);
    }

    public T Remove()
    {
        var lastElement = this.items.Last();

        this.items.RemoveAt(this.Count - 1);

        return lastElement;
    }
}


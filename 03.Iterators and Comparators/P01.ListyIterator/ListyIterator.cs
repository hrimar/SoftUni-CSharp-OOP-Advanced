﻿using System;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T>
{
    private IList<T> collection;
    private int currentIndex = 0;

    public ListyIterator(params T[] collection)
    {
        this.collection = new List<T>(collection);
    }

    public void Create(params T[] elements)
    {
        if (elements.Length == 0)
        {
            this.collection = new List<T>();
        }
        else
        {
            this.collection = elements;
        }
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.currentIndex++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        return this.currentIndex+1 < this.collection.Count;
    }

    public void Print()
    {
        if(this.collection.Count==0)
        {
            throw new ArgumentException("Invalid Operation!");
        }

        Console.WriteLine(collection[currentIndex]);
    }

}

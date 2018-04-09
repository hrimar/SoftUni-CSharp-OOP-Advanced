using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Stack<T> : IEnumerable<T>
{
    private IList<T> items;

    public Stack()
    {
        this.items = new List<T>();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Push(T[] args)
    {
        if (items.Count == 0)
        {
            this.items = new List<T>();
        }
        else if (args.Length == 1)
        {
            items.Add(args[0]);
        }
        if (args.Length > 1)
            items = args.ToList();
       

    }
    public void Pop()
    {
        if (items.Count == 0)
        {
            throw new ArgumentException("No elements");
        }

        var lastElem = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
    }


}


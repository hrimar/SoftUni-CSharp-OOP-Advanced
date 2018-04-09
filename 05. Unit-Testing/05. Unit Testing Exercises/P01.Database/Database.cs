using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Database
{
    private const int MaxCapacity = 16;

    private int currentIndex;
    private int[] values;

    private Database()
    {
        this.values = new int[MaxCapacity];
    }
    public Database(params int[] values)
        : this()
    {
        this.currentIndex = 0;
        this.InitializeValues(values);       
    }

    private void InitializeValues(int[] inputValues)
    {
        try
        {
            Array.Copy(inputValues, this.values, inputValues.Length);
            this.currentIndex = inputValues.Length;
        }
        catch (ArgumentException e)
        {
            throw new InvalidOperationException("The database is full!");
        }

        //foreach (var item in inputValues)
        //{
        //    this.Add(item);
        //}
    }

    public int this[int i]
    {
        get { return this.values[i]; }
    }

    public void Add(int element)
    {
        if (this.currentIndex >= MaxCapacity)
        {
            throw new InvalidOperationException("The database is full!");
        }

        this.values[this.currentIndex] = element;
        this.currentIndex++;
    }

    public void Remove()
    {
        if (this.currentIndex == 0)
        {
            throw new InvalidOperationException("The database is empty!");
        }

        this.currentIndex--;
        this.values[this.currentIndex] = default(int); // 0        
    }

    public int[] Fetch()
    {        
        int[] newArray = new int[currentIndex];
        Array.Copy(this.values, newArray, currentIndex);

        return newArray;
    }
}




using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>  // where T: IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return $"{this.value}";
    }
}


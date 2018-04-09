using System;
using System.Collections.Generic;
using System.Text;

public class Box<T> : IComparable<Box<T>> //: IComparable<List<Box<T>>>
  where T : IComparable<T>
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

    
    public int CompareTo(Box<T> other)
    {       
        int result = this.value.CompareTo(other.value);
       
        return result;
    }

    //public int CompareTo(List<Box<T>> other)
    //{
    //    int count = 0;
    //    foreach (var item in other)
    //    {
    //        if (this.value.CompareTo(item.value) > 0)
    //        {
    //            count++;
    //        }
    //    }
    //    return count;
    //}
}


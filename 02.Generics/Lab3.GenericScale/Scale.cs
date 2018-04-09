using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Scale<T>
    where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }

    public T GetHeavier()
    {
        var result = left.CompareTo(right);

        if (result >0)
        {
            return left;
        }
        else if (result < 0)
        {
            return right;
        }

        return default(T);
    }
}


using System;
using System.Collections.Generic;
using System.Text;

public class Threeuple<T, U, X>
{
    private T element1;
    private U element2;
    private X element3;

    public Threeuple(T element1, U element2, X element3)
    {
        this.element1 = element1;
        this.element2 = element2;
        this.element3 = element3;
    }

    public override string ToString()
    {
        return $"{this.element1} -> {this.element2} -> {this.element3}";
    }
}


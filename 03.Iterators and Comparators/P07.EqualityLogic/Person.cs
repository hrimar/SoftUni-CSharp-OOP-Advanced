using System;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>
{
    public string Name { get;  }

    public int Age { get;  }

    
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
       
    }

    public int CompareTo(Person other)
    {
        var result = this.Name.CompareTo(other.Name);
        if(result==0)
        {
            result = this.Age.CompareTo(other.Age);
        }
        
        return result;
    }

    public override bool Equals(object  obj)
    {
        if (obj is Person other)
        {
            if (this.Name.Equals(other.Name))
            {
                if (this.Age.Equals(other.Age))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public override int GetHashCode()
    {
        return this.Name.GetHashCode() + this.Age.GetHashCode();
    }


    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}


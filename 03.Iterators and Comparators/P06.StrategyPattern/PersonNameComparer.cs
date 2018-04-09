using System;
using System.Collections.Generic;
using System.Text;

public class PersonNameComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Name.Length.CompareTo(y.Name.Length);
        if(result==0)
        {
            // to be caseInsesitive
            result = Char.ToLower(x.Name[0]).CompareTo(Char.ToLower(y.Name[0]));
        }

        return result;
    }
}


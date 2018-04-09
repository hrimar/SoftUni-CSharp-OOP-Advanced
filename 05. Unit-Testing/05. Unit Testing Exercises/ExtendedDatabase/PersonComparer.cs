using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ExtendedDatabase
{
    public class PersonComparer : IEqualityComparer<Person>
    {
       
        public bool Equals(Person x, Person y)
        {
            return x.Username.Equals(y.Username)
                && x.Id == y.Id;
        }

        public int GetHashCode(Person person)
        {
            return new { person.Username, person.Id }.GetHashCode();
        }
    }
}

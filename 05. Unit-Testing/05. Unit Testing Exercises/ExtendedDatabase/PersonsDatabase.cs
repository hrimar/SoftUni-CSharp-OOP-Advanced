using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02.ExtendedDatabase
{
  public  class PersonsDatabase : ExtendedDb<Person>
    {
        public PersonsDatabase(params Person[] persons) 
            : base(persons)
        {
        }

        public override void Add(Person person)
        {
            if (this.CurrentIndex == 0)
            {
                throw new InvalidOperationException("The database is empty!");
            }
            if (this.Elements.Any(p => p.Username.Equals(person.Username)))
            {
                throw new InvalidOperationException("Person with this username already exists.");
            }

            if (this.Elements.Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException("Person with this ID already exists.");
            }

            if (this.CurrentIndex >= MaxCapacity)
            {
                throw new InvalidOperationException("The database is full!");
            }

            this.Elements[this.CurrentIndex] = person;
            this.CurrentIndex++;
        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Empty username provided.");
            }

            if (!this.Elements.Any(p => p.Username.Equals(username)))
            {
                throw new InvalidOperationException("No person with this username was found.");
            }

            return this.Elements.First(p => p.Username.Equals(username));
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id should be positive number.");
            }

            if (!this.Elements.Any(p => p.Id == id))
            {
                throw new InvalidOperationException("Person with this ID was not found.");
            }

            return this.Elements.First(p => p.Id == id);
        }
    }
}

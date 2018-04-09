using NUnit.Framework;
using P02.ExtendedDatabase;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ExtendedDatabaseTests
{
    [TestFixture]
    public class PersonTests
    {
        private readonly IEqualityComparer<Person> personComparer = new PersonComparer();

        [Test]
        public void ConstructorCreatesPersonWithTheProvidedUsernameAndId()
        {           
            Person person = new Person("Naso", 1);
                       
            Assert.IsTrue(this.personComparer.Equals(new Person("Naso", 1), person), "The constructor is not creating the person properly.");
        }
    }
}

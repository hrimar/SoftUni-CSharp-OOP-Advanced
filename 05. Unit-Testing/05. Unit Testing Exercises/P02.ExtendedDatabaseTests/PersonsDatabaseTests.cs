using NUnit.Framework;
using P02.ExtendedDatabase;
using System;
using System.Linq;
using System.Reflection;

namespace P02.ExtendedDatabaseTests
{

    public class PersonsDatabaseTests
    {
        private readonly Person expectedPerson = new Person("Miro", 2);
        private readonly PersonComparer personComparer = new PersonComparer();
        private PersonsDatabase db;

        [SetUp]
        public void CreateSampleDb()
        {
           // db = new PersonsDatabase();
           //// db = new PersonsDatabase(new Person("Toni", 5));
            db = new PersonsDatabase(new Person("Toni", 5), new Person("Miro", 2));
        }


        [Test]
        public void TestValidConstructor()
        {
            Assert.IsTrue(this.personComparer.Equals(this.expectedPerson, this.db[1]));
        }

        [Test]
        public void TestAddInvalidIfPersonWithTheSameNameExists()
        {
            Assert.Throws<InvalidOperationException>(() => 
            this.db.Add(new Person("Toni", 11)), 
            "Person with the same username of an already existing one can be added.");
        }

        
        [Test]
        public void Remove_ShouldThrowExceptionIfTheDatabaseIsEmpty()
        {
            this.db = new PersonsDatabase();

            Assert.Throws<InvalidOperationException>(() => this.db.Remove(), "Exception is not thrown.");
        }

        
        [Test]
        public void FindByUsernameReturnsTheFirstUserWithThatName()
        {
           
            Person person = this.db.FindByUsername("Miro");

            Assert.IsTrue(this.personComparer.Equals(this.expectedPerson, person), "The person is not correctly returned.");
        }
    }
}

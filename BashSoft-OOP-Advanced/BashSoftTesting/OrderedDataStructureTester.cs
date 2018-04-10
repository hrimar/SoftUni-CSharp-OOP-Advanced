using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using BashSoft.Contracts;
using BashSoft.DataStructures;

namespace BashSoftTesting
{
   // [TestClass]
    public class OrderedDataStructureTester
    {

        private const int DefaultCapacity = 16;
        private const int DefaultSize = 0;
        private readonly IList<string> itemsToBeAdded = new List<string>() { "Rocky", "Gandalf", "Asterix", "Merilyn" };
        private ISimpleOrderedBag<string> names;


        // [TestInirialize]
        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        // [TestMethod]
        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

       [Test]
       public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
       // [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrowsException()
        {
           
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null) );
        }

        [Test]
        public void AddAllKeepsSorted()
        {
            // Arrange
            List<string> itemsSorted = this.itemsToBeAdded.OrderBy(i => i).ToList();

            // Act
            this.names.AddAll(this.itemsToBeAdded);

            // Assert
            CollectionAssert.AreEqual(itemsSorted, this.names, "The collection is not sorted.");
        }

        [Test]
        public void RemoveValidElementDecreasesSize()
        {
            // Arrange
            this.names.AddAll(this.itemsToBeAdded);

            // Act
            this.names.Remove("Rocky");

            // Assert
            Assert.AreEqual(this.itemsToBeAdded.Count - 1, this.names.Size, "Removing an element does not decrease the size.");
        }

        [Test]
        public void RemoveValidElementRemovesSelectedOne()
        {           
            // Arrange
            this.names.AddAll(this.itemsToBeAdded);

            // Act
            this.names.Remove("Rocky");

            // Assert
            Assert.IsFalse(this.names.Contains("Rocky"), "The removed element is not the correct one.");
        }

        [Test]
        public void RemovingNullShouldThrowsException()
        {
           
            // Assert 
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null),
                "Trying to remove null from the collection does not throw an exception.");
        }

        [Test]
        public void JoinWithNullShouldThrowException()
        {
          
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null),
                "The collection can be joined with NULL.");
        }

        [Test]
        public void JoinWorksFine()
        {
                      // Arrange
            this.names.AddAll(this.itemsToBeAdded);
            string expectedOutput = "Asterix, Gandalf, Merilyn, Rocky";

            // Act
            string output = this.names.JoinWith(", ");

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }
    }
}

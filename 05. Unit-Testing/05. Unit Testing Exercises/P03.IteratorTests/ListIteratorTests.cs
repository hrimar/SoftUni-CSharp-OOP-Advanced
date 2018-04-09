using NUnit.Framework;
using System;
using System.Collections.Generic;
using P03.IteratorTestProject;

namespace P03.IteratorTests
{
    public class ListIteratorTests
    {
        private ListIterator listIterator;
        private List<string> testCollection;

        [SetUp]
        public void TestInit()
        {
            this.testCollection = new List<string>() { "aaa", "bbb", "ccc" };
            this.listIterator = new ListIterator(this.testCollection);
        }

        [Test]
        public void ConstructorTest_CannotWorkWithNull()
        {
            Assert.That(() => new ListIterator(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructorTest_SuccessfullInitizliceList()
        {
            List<string> expectedColection = new List<string>() { "aaa", "bbb", "ccc" };

            //Assert.That(new ListIterator(this.testCollection), Is.EquivalentTo(expectedColection));
            CollectionAssert.AreEqual(expectedColection, new List<string>() { "aaa", "bbb", "ccc" });
        }

        [Test]
        public void MoveTest_ReturnsFalseWhenThereIsNoMoreElements()
        {
            this.listIterator.Move();
            this.listIterator.Move();

            Assert.False(this.listIterator.Move());
        }

        [Test]
        public void PrintReturnsCurrentElement()
        {
            Assert.That(this.listIterator.Print(), Is.EqualTo("aaa"));
        }

        [Test]
        public void CannotPrintWithEmptyIterator()
        {
            Assert.That(() => new ListIterator(new List<string>()).Print(), Throws.InvalidOperationException);
        }
    }
}

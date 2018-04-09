using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using P04.BubbleSortTestProject;

namespace P04.BubbleSortTest
{
    public class BubbleTests
    {
        
        [Test]
        [TestCase("10, 2, 3, 4, 5, 6, 7, 8, -1")]
        [TestCase("8, 7, 10, 5, 6, 3, 4, -1, 2")]
        public void BubbleMethod_CanSortNumbers(string listString)
        {
            var list = listString.Split(',')
                .Select(int.Parse)
                .ToList();
            var bubble = new Bubble();
            var expectedSortedList = new List<int>() { -1, 2, 3, 4, 5, 6, 7, 8, 10 };

            bubble.Sort(list);

             CollectionAssert.AreEqual(expectedSortedList, list);
        }
    }
}

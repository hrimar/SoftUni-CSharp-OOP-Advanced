using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using P09.DateTimeProject;
using Moq;

namespace P09.DateTimeTests
{
    public class DateTimeTests
    {
        [Test]
        public void AddDaysShoudAddDays()
        {
            DateTime date = new DateTime(2018, 03, 15);
            int daysToAdd = 2;

            Assert.That(date.AddDays(daysToAdd).Day, Is.EqualTo(17));
        }

        [Test]
        public void AddDaysToDateTymeNow_ShoudAddDays()
        {
            DateTime inputData = new DateTime(2008, 02, 28);

            var fakeNow = new Mock<IDateTimeNow>();
            fakeNow.Setup(d => d.Now).Returns(inputData);
            int daysToAdd = 1;
            var result = (fakeNow.Object.Now).AddDays(daysToAdd);
            int expectedDay = 29;

             Assert.That(result.Day, Is.EqualTo(expectedDay));
        }

        [Test]
        public void AddMonthsToDateTymeNow_ShoudAddMonths()
        {
            DateTime inputData = new DateTime(2018, 03, 15);

            var fakeNow = new Mock<IDateTimeNow>();
            fakeNow.Setup(d => d.Now).Returns(inputData);
            int monthsToAdd = 2;
            var result = (fakeNow.Object.Now).AddMonths(monthsToAdd); //  !!!
            int expectedMonths = 5;

            Assert.That(result.Month, Is.EqualTo(expectedMonths));
        }

        [Test]
        public void AddNegativMonthsToDateTymeNow_ShoudBeckMonths()
        {
            DateTime inputData = new DateTime(2018, 03, 15);

            var fakeNow = new Mock<IDateTimeNow>();
            fakeNow.Setup(d => d.Now).Returns(inputData);
            int monthsToAdd = -2;
            var result = (fakeNow.Object.Now).AddMonths(monthsToAdd);
            int expectedMonths = 1;

            Assert.That(result.Month, Is.EqualTo(expectedMonths));
        }

        [Test]
        public void AddDays_SameMonth_WorksCorrectly()
        {
            DateTime dt = new DateTime(2018, 06, 16);

            DateTime expectedResult = new DateTime(2018, 06, 17);
            DateTime actualResult = dt.Add(new TimeSpan(1, 0, 0, 0));

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


        [Test]
        public void AddDays_NonLeapYear_WorksCorrectly()
        {
            DateTime dt = new DateTime(2018, 02, 28);

            DateTime expectedResult = new DateTime(2018, 03, 01);
            DateTime actualResult = dt.Add(new TimeSpan(1, 0, 0, 0));

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}

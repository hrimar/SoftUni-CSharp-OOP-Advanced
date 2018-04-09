using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using Moq;

namespace P07.HackTests
{
    public class MathTests
    {
        [Test]
        [TestCase(-3.56654321)]
        public void Floor_ShoudGivesDonwValue(double inputValue)
        {
            int expectedResult = -4;
            Assert.That(Math.Floor(inputValue), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(-3.56654321)]
        public static void FakeFloor_ShoudGivesDonwValue(double inputValue)
        {
            double expectedResult = -4;

            var fakeMathFloor = new Mock<IMathFloor>();
            fakeMathFloor.Setup(m => m.Floor(inputValue)).Returns(expectedResult);

            var methodResult = (fakeMathFloor.Object).Floor(inputValue);

            Assert.That(methodResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Floor_EqualsValues_WorksCorrectly()
        {
            double expectedResult = -5.0;
            double actualResult = Math.Floor(-5.0);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase(-5555)]
        public void MathAbs_ShoudGivesPositiveValue(int inputValue)
        {
            int expectedResult = 5555;
            Assert.That(Math.Abs(inputValue), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(-3.56654321)]
        public static void FakeMathAbs_ShoudGivesPositiveValue(double inputValue)
        {
            double expectedResult = -4;

            var fakeMathAbs = new Mock<IMathAbs>();
            fakeMathAbs.Setup(m => m.Abs(inputValue)).Returns(expectedResult);

            var methodResult = (fakeMathAbs.Object).Abs(inputValue);

            Assert.That(methodResult, Is.EqualTo(expectedResult));
        }
    }
}

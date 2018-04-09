using NUnit.Framework;
using System;

namespace SkeletonTests
{
    public class AxeTests
    {
        private const int ExpectedAxeDurability = 0;
        private const int AxeAttack = 5;
        private const int DummyHealth = 20;
        private const int DummyXP = 20;

        private Axe axe;

        [SetUp]
        public void InitializeAxe()
        {
         this.axe = new Axe(AxeAttack, ExpectedAxeDurability);
        }

        [TearDown]
        public void TestCleanUp() { }


        [TestCase(AxeAttack, 10, DummyHealth, DummyXP)]
        public void AxeLosesDurabilityAfterAttack(int attack, int durability, int aa, int dd)
        {
            int expectedResult = 9;

            // Arrange
            var axe = new Axe(attack, durability);
            var dummy = new Dummy(aa, dd);

            // Act
            axe.Attack(dummy);

            // Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedResult));
        }

        [Test]
        public void BrokenAxeCannotAttack()
        {
           // var axe = new Axe(5, 0);
            var dummy = new Dummy(DummyHealth, DummyXP);
                        
           
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With
                .Message.EqualTo("Axe is broken."));
        }


    }
}

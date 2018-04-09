using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkeletonTests
{
  public  class HeroTests
    {
        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            var experienceGained = 5;

            var target = new Mock<ITarget>();
            target.Setup(t => t.IsDead()).Returns(true);
            target.Setup(t => t.GiveExperience()).Returns(experienceGained);
            var weapon = new Mock<IWeapon>();
           
            var hero = new Hero("Superman", weapon.Object);
            hero.Attack(target.Object);

            weapon.Verify(w => w.Attack(target.Object));
            
            Assert.That(hero.Experience, Is.EqualTo(experienceGained));
        }
    }
}

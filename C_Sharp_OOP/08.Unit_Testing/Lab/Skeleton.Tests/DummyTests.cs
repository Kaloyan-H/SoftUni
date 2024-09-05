using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void Test_DummyLosesHealthWhenAttacked()
        {
            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health, "Dummy doesn't lose intended health when attacked.");
        }
        [Test]
        public void Test_AttackingDeadDummyThrows()
        {
            dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(5);
            });
        }
        [Test]
        public void Test_DeadDummyGivesExperience()
        {
            dummy = new Dummy(0, 10);

            int experienceGiven = dummy.GiveExperience();

            Assert.AreEqual(10, experienceGiven, "Dummy doesn't give intended experience.");
        }
        [Test]
        public void Test_AliveDummyCannotGiveExperience()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            }, "Dummy can give experience when alive.");
        }
    }
}
using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void Test_AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints, "Axe durability doesn't change after attack.");
        }
        [Test]
        public void Test_AttackingWithNoDurabilityShouldNotWork()
        {
            axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }, "Axe shouldn't be able to attack with less than or equal to 0 durability.");
        }
    }
}
using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            FootballTeam footballTeam = new FootballTeam("Test", 10);
        }

        [Test]
        public void Test_ConstructorWorksAsIntended()
        {
            FootballTeam footballTeam = new FootballTeam("Test", 20);
            Assert.AreEqual("Test", footballTeam.Name, "Constructor doesn't work as intended.");
            Assert.AreEqual(10, footballTeam.Capacity, "Constructor doesn't work as intended.");
        }
        [Test]
        public void Test_NameSet_ThrowsWhenNullOrEmpty()
        {
            FootballTeam footballTeam = new FootballTeam("Test", 20);
            Assert.Throws<ArgumentException>(() =>
            {
                footballTeam.Name = null;
            }, "Name setter doesn't work as intended.");
        }
        [Test]
        public void Test_CapacitySet_ThrowsWhenLessThanFifteen()
        {
            FootballTeam footballTeam = new FootballTeam("Test", 20);
            Assert.Throws<ArgumentException>(() =>
            {
                footballTeam.Capacity = 5;
            }, "Capacity setter doesn't work as intended.");
        }
        [Test]
        public void Test_AddNewPlayer_ReturnsErrorWhenOverTheLimit()
        {
            FootballTeam footballTeam = new FootballTeam("Test", 15); 

            for (int i = 0; i < 15; i++)
            {
                footballTeam.AddNewPlayer(new FootballPlayer("test", i, "test"));
            }
        }
    }
}
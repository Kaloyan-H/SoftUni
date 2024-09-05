namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq.Expressions;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person[] emptyPeopleArray = new Person[0];
        private Person[] twoDifferentPeople = new Person[]
        {
            new Person(1, "One"),
            new Person(2, "Two"),
        };
        private Person[] twoIdenticalIdPeople = new Person[]
        {
            new Person(0, "One"),
            new Person(0, "Two"),
        };
        private Person[] twoIdenticalNamePeople = new Person[]
        {
            new Person(1, "Person"),
            new Person(2, "Person"),
        };
        private Person[] sixteenDifferentPeople = new Person[]
        {
            new Person(1, "One"),
            new Person(2, "Two"),
            new Person(3, "Three"),
            new Person(4, "Four"),
            new Person(5, "Five"),
            new Person(6, "Six"),
            new Person(7, "Seven"),
            new Person(8, "Eight"),
            new Person(9, "Nine"),
            new Person(10, "Ten"),
            new Person(11, "Eleven"),
            new Person(12, "Twelve"),
            new Person(13, "Thirteen"),
            new Person(14, "Fourteen"),
            new Person(15, "Fifteen"),
            new Person(16, "Sixteen"),
        };
        private Person[] seventeenDifferentPeople = new Person[]
        {
            new Person(1, "One"),
            new Person(2, "Two"),
            new Person(3, "Three"),
            new Person(4, "Four"),
            new Person(5, "Five"),
            new Person(6, "Six"),
            new Person(7, "Seven"),
            new Person(8, "Eight"),
            new Person(9, "Nine"),
            new Person(10, "Ten"),
            new Person(11, "Eleven"),
            new Person(12, "Twelve"),
            new Person(13, "Thirteen"),
            new Person(14, "Fourteen"),
            new Person(15, "Fifteen"),
            new Person(16, "Sixteen"),
            new Person(17, "Seventeen"),
        };

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Test_Constructor_WorksWithNoPeople()
        {
            Assert.DoesNotThrow(() =>
            {
                database = new Database(emptyPeopleArray);
            }, "Database constructor doesn't with no people.");
        }
        [Test]
        public void Test_Constructor_WorksWithValidNumberOfPeople()
        {
            Assert.DoesNotThrow(() =>
            {
                database = new Database(twoDifferentPeople);
            }, "Database constructor doesn't with a valid amount of people.");
        }
        [Test]
        public void Test_Constructor_WorksWithSixteenPeople()
        {
            Assert.DoesNotThrow(() =>
            {
                database = new Database(sixteenDifferentPeople);
            }, "Database constructor doesn't with sixteen people.");
        }
        [Test]
        public void Test_Constructor_ThrowsWithMoreThanSixteenPeople()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                database = new Database(seventeenDifferentPeople);
            }, "Database works with more than sixteen people.");
        }

        [Test]
        public void Test_Count_ReturnsCollectionSizeCorrectly()
        {
            int expectedCount = twoDifferentPeople.Length;

            database = new Database(twoDifferentPeople);

            Assert.AreEqual(expectedCount, database.Count,
                "Count property doesn't return collection size correclty.");
        }

        [Test]
        public void Test_Add_WorksWithADifferentPerson()
        {
            database = new Database(twoDifferentPeople);

            Assert.DoesNotThrow(() =>
            {
                database.Add(new Person(3, "Three"));
            }, "Add method doesn't work with a different person.");
        }
        [Test]
        public void Test_Add_ThrowsWhenCollectionIsFull()
        {
            database = new Database(sixteenDifferentPeople);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(17, "Seventeen"));
            }, "Add method doesn't throw when collection is full.");
        }
        [Test]
        public void Test_Add_ThrowsWhenPersonWithThatIdExists()
        {
            database = new Database(twoDifferentPeople);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(1, "Person"));
            }, "Add method doesn't throw when trying to add a person with an id that already exists.");
        }
        [Test]
        public void Test_Add_ThrowsWhenPersonWithThatUsernameExists()
        {
            database = new Database(twoDifferentPeople);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(0, "One"));
            }, "Add method doesn't throw when trying to add a person with a username that already exists.");
        }
        [Test]
        public void Test_Add_IncreasesCountCorrectly()
        {
            database = new Database(twoDifferentPeople);
            database.Add(new Person(3, "Three"));

            int expectedCount = twoDifferentPeople.Length + 1;

            Assert.AreEqual(expectedCount, database.Count,
                "Add method doesn't increase Count correctly.");
        }

        [Test]
        public void Test_Remove_WorksWhenCountIsMoreThanZero()
        {
            database = new Database(twoDifferentPeople);

            Assert.DoesNotThrow(() =>
            {
                database.Remove();
            }, "Remove method doesn't work when there are more than zero elements.");
        }
        [Test]
        public void Test_Remove_ThrowsWhenCountIsZero()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "Remove method doesn't throw when there are no elements.");
        }
        [Test]
        public void Test_Remove_DecreasesCountCorrectly()
        {
            database = new Database(twoDifferentPeople);
            database.Remove();

            int expectedCount = twoDifferentPeople.Length - 1;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void Test_FindByUsername_WorksCorrectlyWithValidUsername()
        {
            database = new Database(twoDifferentPeople);
            Person expectedPerson = new Person(1, "One");
            Person actualPerson = database.FindByUsername("One");

            Assert.AreEqual(expectedPerson.Id, actualPerson.Id,
                "FindByUsername method doesn't return a person with the correct id.");
            Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName,
                "FindByUsername method doesn't return a person with the correct name.");
        }
        [Test]
        public void Test_FindByUsername_ThrowsWhenUsernameParameterIsNull()
        {
            database = new Database(twoDifferentPeople);

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            }, "FindByUsername method doesn't throw when the username parameter is null.");
        }
        [Test]
        public void Test_FindByUsername_ThrowsWhenThereIsNoPersonWithThatUsername()
        {
            database = new Database(twoDifferentPeople);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("nonexistent");
            }, "FindByUsername method doesn't throw when a perdon with that username doesn't exist.");
        }

        [Test]
        public void Test_FindById_WorksCorrectlyWithValidId()
        {
            database = new Database(twoDifferentPeople);
            Person expectedPerson = new Person(1, "One");
            Person actualPerson = database.FindById(1);

            Assert.AreEqual(expectedPerson.Id, actualPerson.Id,
                "FindById method doesn't return a person with the correct id.");
            Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName,
                "FindById method doesn't return a person with the correct name.");
        }
        [Test]
        public void Test_FindById_ThrowsWhenIdParameterIsLessThanZero()
        {
            database = new Database(twoDifferentPeople);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            }, "FindById method doesn't throw if the id parameter is less than zero.");
        }
        [Test]
        public void Test_FindById_ThrowsWhenThereIsNoPersonWithThatId()
        {
            database = new Database(twoDifferentPeople);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(0);
            });
        }
    }
}
namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private int[] paramsOneToEigth = new int[]
        {
            1, 2, 3, 4,
            5, 6, 7, 8
        };

        [SetUp]
        public void SetUp()
        {
            database = new Database(paramsOneToEigth);
        }

        [Test]
        public void Test_Constructor_SetsCountCorrectly()
        {
            Assert.AreEqual(paramsOneToEigth.Length, database.Count,
                "Constructor doesn't set the Count correctly.");
        }
        [Test]
        public void Test_Count_ReturnsTheCorrectCount()
        {
            Assert.AreEqual(paramsOneToEigth.Length, database.Count);
        }
        [Test]
        public void Test_Add_IncreasesCount()
        {
            database.Add(5);

            Assert.AreEqual(paramsOneToEigth.Length + 1, database.Count,
                "Add method doesn't increase Count correctly.");
        }
        [Test]
        public void Test_Add_ThrowsWhenDatabaseIsFull()
        {
            database = new Database(
                1, 2, 3, 4,
                5, 6, 7, 8,
                9, 10, 11, 12,
                13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(5);
            }, "Add method doesn't throw an exception when trying to add elements into full database.");
        }
        [Test]
        public void Test_Remove_DecreasesCount()
        {
            database.Remove();

            Assert.AreEqual(paramsOneToEigth.Length - 1, database.Count,
                "Remove method doesn't decrease Count correctly.");
        }
        [Test]
        public void Test_Remove_ThrowsWhenDatabaseIsEmpty()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "Remove method doesn't throw an exception when trying to remove elements from an empty database.");
        }
        [Test]
        public void Test_Fetch_ReturnsTheArrayCorrectly()
        {

            int[] intArr = database.Fetch();

            Assert.AreEqual(paramsOneToEigth.Length, intArr.Length,
                "Fetch method doesn't return an array with the correct length.");

            for (int i = 0; i < intArr.Length; i++)
            {
                Assert.AreEqual(paramsOneToEigth[i], intArr[i],
                    $"Fetch method doesn't return the elements of the database correctly.");
            }
        }
    }
}

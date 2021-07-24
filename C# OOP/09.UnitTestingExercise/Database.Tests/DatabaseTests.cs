using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Add_IncreasesDatabaseCount_WhenCapacityIsNotExceeded()
        {
            database.Add(123);
            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_AddElementToDatabase()
        {
            int element = 123;
            database.Add(element);
            int[] elements = database.Fetch();
            Assert.IsTrue(elements.Contains(element));
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_DecreasesDatabaseCount()
        {
            database.Add(1);
            database.Add(2);
            database.Add(3);
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void Remove_RemovesElementFromDatabase()
        {
            database.Add(1);
            database.Add(2);
            database.Add(3);
            database.Remove();
            int[] elements = database.Fetch();
            Assert.IsFalse(elements.Contains(3));
        }

        [Test]
        public void Fetch_ReturnsDatabaseCopy()
        {
            database.Add(1);
            database.Add(2);
            int[] firstCopy = database.Fetch();
            database.Add(3);
            int[] secondCopy = database.Fetch();
            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }

        [Test]
        public void Count_ReturnsZero_WhenDatabaseIsEmpty()
        {
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_AddsElementsToDatabase()
        {
            int[] arr = new int[] { 1, 2, 3 };
            database = new Database.Database(arr);
            Assert.That(database.Count, Is.EqualTo(arr.Length));
            Assert.That(database.Fetch(), Is.EqualTo(arr));
        }

        [Test]
        public void Ctor_ThrowsException_WhenCapacityIsExceeded()
        {
            int[] arr = new int[] { 1, 2, 3 ,4,5,6,7,8,9,10,11,12,13,14,15,16,17};
            Assert.Throws<InvalidOperationException>(() => database=new Database.Database(arr));
        }
    }
}
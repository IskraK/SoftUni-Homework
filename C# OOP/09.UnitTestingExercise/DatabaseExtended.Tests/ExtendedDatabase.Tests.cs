using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Add_ThrowsException_WhenDatabaseCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, $"Username{i}"));
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(16, "Username")));
        }

        [Test]
        public void Add_ThrowsException_WhenUsernameIsUsed()
        {
            database.Add(new Person(1, "Username"));
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, "Username")));
        }

        [Test]
        public void Add_ThrowsException_WhenIdIsUsed()
        {
            database.Add(new Person(1, "Username"));
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "Username2")));
        }

        [Test]
        public void Add_IncreasesCount_WhenUserIsValid()
        {
            database.Add(new Person(1, "Username1"));
            database.Add(new Person(2, "Username2"));
            int expectedCount = 2;
            Assert.That(database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_ThrowsException_WhendatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_RemovesElementFromDB()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, $"Username{i}"));
            }

            database.Remove();
            Assert.That(database.Count, Is.EqualTo(n - 1));
            Assert.Throws<InvalidOperationException>(() => database.FindById(n - 1));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_ThrowsException_WhenUsernameIsNotValid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_Throwsexception_WhenUsernameDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("name"));
        }

        [Test]
        public void FindByUsername_ReturnsUser_WhenUserExists()
        {
            Person person = new Person(1, "Username");
            database.Add(person);
            Person personDB = database.FindByUsername(person.UserName);
            Assert.That(person, Is.EqualTo(personDB));
        }


        [Test]
        [TestCase(-2)]
        public void FindById_ThrowsException_WhenIdIsNotValid(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }

        [Test]
        public void FindById_ThrowsException_WhenIdDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(2));
        }

        [Test]
        public void FindById_ReturnsUser_WhenUserExists()
        {
            Person person = new Person(1, "Username");
            database.Add(person);
            Person personDB = database.FindById(person.Id);
            Assert.That(person, Is.EqualTo(personDB));
        }

        [Test]
        public void Ctor_ThrowsException_WhenCapacityIsExceeded()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username{i}");
            }

            Assert.Throws<ArgumentException>(() => database = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void Ctor_AddPeopleToDatabase()
        {
            Person[] people = new Person[5];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username{i}");
            }

            database = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.That(database.Count, Is.EqualTo(people.Length));

            foreach (var person in people)
            {
                Person personDB = database.FindById(person.Id);
                Assert.That(person, Is.EqualTo(personDB));
            }
        }
    }
}
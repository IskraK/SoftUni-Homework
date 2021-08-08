namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void Setup()
        {
            bag = new Bag();
        }

        [Test]
        public void Create_ThrowsException_WhenPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void Create_ThrowsException_WhenPresentExists()
        {
            Present present = new Present("A", 1);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void Create_ReturnCorrectResult_WhenPresentIsValid()
        {
            Present present = new Present("A", 1);
            string expected = bag.Create(present);
            string actual = $"Successfully added present A.";
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Remove_WorksCorrect()
        {
            Present present = new Present("A", 1);
            bag.Create(present);
            Assert.That(() => bag.Remove(present), Is.True);
        }

        [Test]
        public void GetPresentWithLeastMagic_WorksCorrect()
        {
            Present present = new Present("A", 1);
            Present present2 = new Present("B", 2);
            bag.Create(present);
            bag.Create(present2);
            Assert.That(() => bag.GetPresentWithLeastMagic(), Is.EqualTo(present));
        }

        [Test]
        public void GetPresent_WorksCorrect()
        {
            Present present = new Present("A", 1);
            Present present2 = new Present("B", 2);
            bag.Create(present);
            bag.Create(present2);
            Assert.That(() => bag.GetPresent("A"), Is.EqualTo(present));
        }

        [Test]
        public void GetPresents_WorksCorrect()
        {
            Present present = new Present("A", 1);
            Present present2 = new Present("B", 2);
            bag.Create(present);
            bag.Create(present2);
            Assert.That(() => bag.GetPresents(), Is.Not.Null);
        }

        [Test]
        public void Ctor_InitializeCollection()
        {
            Present present = new Present("A", 1);
            Present present2 = new Present("B", 2);
            bag.Create(present);
            bag.Create(present2);
            List<Present> presents = new List<Present>();
            Assert.That(presents, Is.Not.Null);

            presents.Add(present);
            Assert.That(presents.Count, Is.EqualTo(1));
        }
    }
}

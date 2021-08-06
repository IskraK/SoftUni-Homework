namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;


        [SetUp]
        public void Setup()
        {
            aquarium = new Aquarium("Aqua", 2);
            fish = new Fish("fish1");
        }

        [Test]
        [TestCase(null,1)]
        [TestCase("",1)]
        public void PropName_ThrowsEaxception_WhenAquariumNameIsNullOrEmpty(string name,int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name,capacity));
        }

        [Test]
        [TestCase("AA", -10)]
        [TestCase("BB", -1)]
        public void PropCapacity_ThrowsEaxception_WhenAquariumCapacityIsLessThanZero(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void Add_ThrowsEaxception_WhenAquariumIsFull()
        {
            aquarium.Add(fish);
            aquarium.Add(new Fish("fish2"));
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("fish3")));
        }

        [Test]
        public void Add_AquariumSuccessfullyAddsFish_WhenCapacityIsNotExceeded()
        {
            aquarium.Add(fish);
            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveFish_ThrowsEaxception_WhenFishDoesNotExist()
        {
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("fish"));
        }

        [Test]
        public void RemoveFish_SuccessfullyRemoveFish_WhenFishExists()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish("fish1");
            Assert.That(aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void SellFish_ThrowsEaxception_WhenFishDoesNotExist()
        {
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("fish"));
        }

        [Test]
        public void SellFish_SuccessfullySellFish_WhenFishExists()
        {
            aquarium.Add(fish);
            Fish requiredFish = aquarium.SellFish("fish1");
            Assert.That(aquarium.Count, Is.EqualTo(1));
            Assert.That(requiredFish, Is.EqualTo(fish));
            Assert.That(requiredFish.Name, Is.EqualTo(fish.Name));
            Assert.That(requiredFish.Available, Is.EqualTo(false));
        }

        [Test]
        public void Report_ReturnsCorrectString()
        {
            aquarium.Add(fish);
            string expectedReport = $"Fish available at {aquarium.Name}: {fish.Name}";
            string actualReport = aquarium.Report();
            Assert.That(actualReport, Is.EqualTo(expectedReport));
        }

        [Test]
        public void Report_ReturnsCorrectString_WhenListOfFishes()
        {
            List<string> fishNames = new List<string> { "fish1", "fish2", "fish3" };
            Aquarium aqua = new Aquarium("AAA", 10);

            foreach (var name in fishNames)
            {
                aqua.Add(new Fish(name));
            }
            string expectedReport = $"Fish available at {aqua.Name}: {string.Join(", ",fishNames)}";
            string actualReport = aqua.Report();
            Assert.That(actualReport, Is.EqualTo(expectedReport));
        }
    }
}

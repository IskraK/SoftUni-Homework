using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverExists()
        {
            UnitCar car = new UnitCar("Model", 100, 500);
            UnitDriver driver = new UnitDriver("Name", car);
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriver_IncreasesCount_WhenDriverIsValid()
        {
            UnitCar car = new UnitCar("Model", 100, 500);
            UnitDriver driver = new UnitDriver("Name", car);
            raceEntry.AddDriver(driver);
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]  // Judge don't check the message => the test is unnecessary !!!
        public void AddDriver_ReturnsCorrectMessage_WhenDriverIsValid()
        {
            UnitCar car = new UnitCar("Model", 100, 500);
            UnitDriver driver = new UnitDriver("Pesho", car);
            string result = raceEntry.AddDriver(driver);
            Assert.That(result, Is.EqualTo("Driver Pesho added in race."));
            //Assert.AreEqual("Driver Pesho added in race.", result);  // It's correct
            //Assert.AreEqual(result, "Driver Pesho added in race.");  // It's also works
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsException_WhenDriversAreLessThanMinimum()
        {
            UnitCar car = new UnitCar("Model", 100, 500);
            UnitDriver driver = new UnitDriver("Name", car);
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ReturnsAverageHorsePower_WhenDriversAreMoreThanMinimum()
        {
            UnitCar car = new UnitCar("Model", 100, 500);
            UnitDriver driver = new UnitDriver("Name", car);
            raceEntry.AddDriver(driver);
            UnitCar car2 = new UnitCar("Model2", 200, 500);
            UnitDriver driver2 = new UnitDriver("Name2", car2);
            raceEntry.AddDriver(driver2);
            double expectedAvgHorsePower=(driver.Car.HorsePower+driver2.Car.HorsePower)/ 2;
            Assert.That(raceEntry.CalculateAverageHorsePower(),Is.EqualTo(expectedAvgHorsePower));
        }
    }
}
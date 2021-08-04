namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "RegNumber");
            softPark = new SoftPark();
        }

        [Test]
        public void Ctor_InitializeDictionary()
        {
            Assert.That(softPark.Parking, Is.Not.Null);
        }


        [Test]
        public void Ctor_ReturnsCorrectCount()
        {
            Assert.That(softPark.Parking.Count, Is.EqualTo(12));
            foreach (var item in softPark.Parking)
            {
                Assert.That(softPark.Parking[item.Key], Is.EqualTo(null));
            }
        }


        [Test]
        public void Ctor_CreateCorrectParking()
        {
            var myParking = new Dictionary<string, Car>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            foreach (var item in softPark.Parking)
            {
                Assert.That(myParking.ContainsKey(item.Key),Is.EqualTo(true));
                Assert.That(myParking[item.Key], Is.EqualTo(null));
            }
        }


        [Test]
        public void ParkCar_ThrowsException_WhenParkSpotDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A11", car));
        }

        [Test]
        public void ParkCar_ThrowsException_WhenParkSpotIsTaken()
        {
            softPark.ParkCar("A1", car);
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A1", new Car("Make2", "RegNumber2")));
        }

        [Test]
        public void ParkCar_ThrowsException_WhenCarIsAlreadyParked()
        {
            softPark.ParkCar("A1", car);
            Assert.Throws<InvalidOperationException>(() => softPark.ParkCar("A2", car));
        }

        [Test]
        public void ParkCar_WorksCorrect_WhenDataAreValid()
        {
            softPark.ParkCar("A1", car);
            Assert.That(softPark.Parking["A1"], Is.EqualTo(car));
        }

        [Test]
        public void ParkCar_ReturnsCorrectMessage_WhenDataAreValid()
        {
            string result = softPark.ParkCar("A1", car);
            Assert.That(result, Is.EqualTo($"Car:{car.RegistrationNumber} parked successfully!"));
        }

        [Test]
        public void RemoveCar_ThrowsException_WhenParkSpotDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A11", car));
        }

        [Test]
        public void RemoveCar_ThrowsException_WhenParkedCarDoesNotExist()
        {
            softPark.ParkCar("A1", car);
            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("A1", new Car("Make2", "RegNumber2")));
        }

        [Test]
        public void RemoveCar_WorksCorrect_WhenDataAreValid()
        {
            softPark.ParkCar("A1", car);
            softPark.RemoveCar("A1", car);
            Assert.That(softPark.Parking["A1"], Is.EqualTo(null));
        }

        [Test]
        public void RemoveCar_ReturnsCorrectMessage_WhenDataAreValid()
        {
            softPark.ParkCar("A1", car);
            softPark.ParkCar("A2", new Car("Make2", "RegNumber2"));
            string result = softPark.RemoveCar("A1", car);
            Assert.That(result, Is.EqualTo($"Remove car:{car.RegistrationNumber} successfully!"));
        }
    }
}
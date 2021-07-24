using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 10, 100);
        }

        [Test]
        //[TestCase("Make","Model",10,100)]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -100)]
        public void Ctor_ThrowsException_WhenArgsAreInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_SetValues_WhenArgsAreValid()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void Refuel_ThrowsException_WhenFuelIsInvalid(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void Refuel_IncreasesFuelAmount_WhenFuelIsValid()
        {
            car.Refuel(car.FuelCapacity / 2);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity / 2));
        }

        [Test]
        public void Refuel_SetFuelAmountToCapacity_WhenCapacityIsExceeded()
        {
            car.Refuel(car.FuelCapacity * 2);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowsException_WhenTankIsNotFullEnough()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(200));
        }

        [Test]
        public void Drive_DecreasesFuelAmount_WhenDistanseIsValid()
        {
            double fuel = car.FuelCapacity;
            car.Refuel(fuel);
            car.Drive(100);
            Assert.That(car.FuelAmount, Is.EqualTo(fuel - car.FuelConsumption));
        }
    }
}
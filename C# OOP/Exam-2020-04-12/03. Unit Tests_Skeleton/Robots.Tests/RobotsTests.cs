namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public void Setup()
        {
            robot = new Robot("robotName",10);
            manager = new RobotManager(3);
        }
        [Test]
        public void Ctor_SetProperties_WhenCreateRobot()
        {
            string name = "robotName";
            int maximumBattery = 10;
            
            Assert.That(robot.Name,Is.EqualTo(name));
            Assert.That(robot.MaximumBattery,Is.EqualTo(maximumBattery));
            Assert.That(robot.Battery,Is.EqualTo(maximumBattery));
        }

        [Test]
        public void Ctor_SetCapacity_WhenCreateRobotManager()
        {
            Assert.That(manager.Capacity, Is.EqualTo(3));
        }

        [Test]
        public void Capacity_ThrowsException_WhenValueIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-2));
        }

        [Test]
        public void Add_ThrowsException_WhenRobotExists()
        {
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Add(robot));
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            manager.Add(robot);
            manager.Add(new Robot("N2",2));
            manager.Add(new Robot("N3", 3));
            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot("N4", 4)));
            Assert.That(manager.Count, Is.EqualTo(3));
        }

        [Test]
        public void Add_WorksCorrect_WhenArgsAreValid()
        {
            manager.Add(robot);
            manager.Add(new Robot("N2", 2));
            Assert.That(manager.Count, Is.EqualTo(2));
        }

        [Test]
        public void Remove_ThrowsException_WhenRobotDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Remove(robot.Name));
        }

        [Test]
        public void Remove_WorksCorrect_WhenRobotExists()
        {
            manager.Add(robot);
            manager.Remove(robot.Name);
            Assert.That(manager.Count,Is.EqualTo(0));
        }

        [Test]
        public void Work_ThrowsException_WhenRobotDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Work("robotName", "job", 2));
        }

        [Test]
        public void Work_ThrowsException_WhenRobotBaterryIsLessThanBatteryUsage()
        {
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Work("robotName", "job", 20));
        }

        [Test]
        public void Work_DecreasesRobotBattery_WhenArgsAreValid()
        {
            manager.Add(robot);
            manager.Work("robotName", "job", 2);
            Assert.That(robot.Battery, Is.EqualTo(8));
        }

        [Test]
        public void Charge_ThrowsException_WhenRobotDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Charge("robotName"));
        }

        [Test]
        public void Charge_SetBatteryToMax_WhenRobotExists()
        {
            manager.Add(robot);
            manager.Work(robot.Name, "job", 5);
            manager.Charge(robot.Name);
            Assert.That(robot.Battery, Is.EqualTo(robot.MaximumBattery));
        }
    }
}

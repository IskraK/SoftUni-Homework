using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races.Entities;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = carRepository.GetByName(carModel);
            IDriver driver = driverRepository.GetByName(driverName);

            if (car == null)
            {
                throw new  InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
            
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver = driverRepository.GetByName(driverName);
            IRace race = raceRepository.GetByName(raceName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = default;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else
            {
                car = new SportsCar(model, horsePower);
            }

            carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, car.Model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            IDriver[] sortedDrivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToArray();

            raceRepository.Remove(race);

            IDriver firstDriver = sortedDrivers[0];
            IDriver secondDriver = sortedDrivers[1];
            IDriver thirdDriver = sortedDrivers[2];

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition,firstDriver.Name,raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition,secondDriver.Name,raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition,thirdDriver.Name,raceName));

            return sb.ToString().TrimEnd();
        }
    }
}

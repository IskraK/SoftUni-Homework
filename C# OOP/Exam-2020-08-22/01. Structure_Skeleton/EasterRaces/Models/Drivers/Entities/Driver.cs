﻿using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

using System;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            this.Name = name;  
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }
        

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                CanParticipate = false;
                throw new ArgumentNullException(String.Format(ExceptionMessages.CarInvalid));
            }
            CanParticipate = true;
            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}

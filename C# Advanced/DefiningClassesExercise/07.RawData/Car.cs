using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Car
    {
        public Car(string model,Engine engine,Cargo cargo,Tire[]tires)
        {
            this.Model = model;
            this.CarEngine = engine;
            this.CarCargo = cargo;
            this.CarTires = tires;
        }
        public string Model { get; set; }
        public Engine CarEngine { get; set; }
        public Cargo CarCargo { get; set; }
        public Tire[] CarTires { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car()
        {
            Weight = "n/a";
            Color = "n/a";
        }
        public Car(string model, Engine engine)
            :this()
        {
            this.Model = model;
            this.CarEngine = engine;
        }
        public string Model { get; set; }
        public Engine CarEngine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {CarEngine.EngineModel}:");
            sb.AppendLine($"    Power: {CarEngine.Power}");
            sb.AppendLine($"    Displacement: {CarEngine.Displacement}");
            sb.AppendLine($"    Efficiency: {CarEngine.Efficiency}");
            sb.AppendLine($"  Weight: {Weight}");
            sb.Append($"  Color: {Color}");

            return sb.ToString();
        }
    }
}

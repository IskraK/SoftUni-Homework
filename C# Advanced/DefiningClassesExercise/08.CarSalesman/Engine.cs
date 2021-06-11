namespace _08.CarSalesman
{
    public class Engine
    {
        public Engine()
        {
            Displacement = "n/a";
            Efficiency = "n/a";
        }
        public Engine(string model,int power)
            :this()
        {
            this.EngineModel = model;
            this.Power = power;
        }

        public string EngineModel { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

    }
}
namespace _07.RawData
{
    public class Tire
    {
        public Tire(double pressure,int age)
        {
            this.TirePressure = pressure;
            this.TireAge = age;
        }
        public int TireAge { get; set; }
        public double TirePressure { get; set; }
    }
}
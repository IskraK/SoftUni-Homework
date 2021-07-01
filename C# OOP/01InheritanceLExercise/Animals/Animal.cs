using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private int age;
        public string Name { get; set; }
        public int Age 
        { 
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Invalid input!");
                }
                this.age = value;
            }
        }
        public string Gender { get; set; }

        public Animal(string name,int age,string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());
            return sb.ToString().TrimEnd();
        }
    }
}

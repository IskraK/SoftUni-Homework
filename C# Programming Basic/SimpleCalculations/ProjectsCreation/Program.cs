using System;

namespace ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfTheArchitect = Console.ReadLine();
            int numberOfProjects = int.Parse(Console.ReadLine());
            int timeNeedForOneProject = 3;
            int timeNeedForAllProjects = numberOfProjects * timeNeedForOneProject;
            Console.WriteLine($"The architect {nameOfTheArchitect} will need {timeNeedForAllProjects} hours to complete {numberOfProjects} project/s.");
        }
    }
}

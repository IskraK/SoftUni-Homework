using System;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int numberDoctors = 7;
            int treatedPatientsForDay = 0;
            int untreatedPatientsForDay = 0;
            int treatedPatients = 0;
            int untreatedPatients = 0;
            for (int i = 1; i <= days; i++)
            {
                int patientsForDay = int.Parse(Console.ReadLine());
                if (patientsForDay >= numberDoctors)
                {
                    treatedPatientsForDay= numberDoctors;
                    untreatedPatientsForDay= patientsForDay - treatedPatientsForDay;
                }
                else
                {
                    treatedPatientsForDay = patientsForDay;
                    untreatedPatientsForDay = 0;
                }
                if (i % 3 == 0 && untreatedPatients > treatedPatients)
                {
                    ++numberDoctors;
                    if (patientsForDay >= numberDoctors)
                    {
                        treatedPatientsForDay = numberDoctors;
                        untreatedPatientsForDay = patientsForDay - treatedPatientsForDay;
                    }
                    else
                    {
                        treatedPatientsForDay = patientsForDay;
                        untreatedPatientsForDay = 0;
                    }
                }
                treatedPatients += treatedPatientsForDay;
                untreatedPatients += patientsForDay - treatedPatientsForDay;
            }
            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}

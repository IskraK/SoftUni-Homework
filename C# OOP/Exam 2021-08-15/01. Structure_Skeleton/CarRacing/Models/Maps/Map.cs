using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (racerTwo.IsAvailable() == false && racerOne.IsAvailable())
            {
                string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            /*if (racerOne.IsAvailable()  && racerTwo.IsAvailable())*/
            racerOne.Race();
            racerTwo.Race();

            double racingBehaviorMultiplier = 0; ;

            if (racerOne.RacingBehavior == "strict" || racerTwo.RacingBehavior == "strict")
            {
                racingBehaviorMultiplier = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive" || racerTwo.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplier = 1.1;
            }

            double chanceOfWinning1 = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplier;
            double chanceOfWinning2 = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplier;

            if (chanceOfWinning1 > chanceOfWinning2)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }

        }
    }
}

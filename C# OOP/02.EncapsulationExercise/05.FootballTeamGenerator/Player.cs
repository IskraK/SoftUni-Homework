using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private int MinSkillValue = 0;
        private int MaxSkillValue = 100;
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }


        public int Endurance
        {
            get { return endurance; }
            private set
            {
                ValidateStat(value, nameof(Endurance));
                endurance = value;
            }
        }

        public int Sprint
        {
            get { return sprint; }
            private set
            {
                ValidateStat(value, nameof(Sprint));
                sprint = value;
            }
        }

        public int Dribble
        {
            get { return dribble; }
            private set
            {
                ValidateStat(value, nameof(Dribble));
                dribble = value;
            }
        }

        public int Passing
        {
            get { return passing; }
            private set
            {
                ValidateStat(value, nameof(Passing));
                passing = value;
            }
        }

        public int Shooting
        {
            get { return shooting; }
            private set
            {
                ValidateStat(value, nameof(Shooting));
                shooting = value;
            }
        }

        private int SkillLevel()
        {
            double countSkills = 5.0;
            return (int)Math.Round((Endurance + Sprint + Dribble + Passing + Shooting) / countSkills);
        }

        public int GetSkillLevel => SkillLevel();

        private void ValidateStat(int value, string statName)
        {
            if (value <= MinSkillValue || value >= MaxSkillValue)
            {
                throw new ArgumentException($"{statName} should be between {MinSkillValue} and {MaxSkillValue}.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Iterfaces
{
    public interface IRepair
    {
        public string PartName { get; }
        public int HoursWorked { get; }
    }
}

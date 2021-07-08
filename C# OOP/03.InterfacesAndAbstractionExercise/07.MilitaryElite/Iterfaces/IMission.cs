using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Iterfaces
{
    public interface IMission
    {
        public string CodeName { get; }
        public string State { get; }

        void CompleteMission();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Iterfaces
{
    public interface ISoldier
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}

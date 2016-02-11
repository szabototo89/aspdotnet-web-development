﻿using System;
using System.Collections.Generic;
using SuperHeroManager.DataModels.Common;

namespace SuperHeroManager.DataModels.Superheroes
{
    public class Team : EntityBase
    {
        public String Name { get; set; }

        public virtual List<SuperHero> SuperHeroes { get; set; } 
    }
}
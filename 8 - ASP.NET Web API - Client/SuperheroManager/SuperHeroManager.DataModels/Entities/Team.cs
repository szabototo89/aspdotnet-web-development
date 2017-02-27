using System;
using System.Collections.Generic;
using SuperHeroManager.DataModels.Common;

namespace SuperHeroManager.DataModels.Entities
{
    public class Team : EntityBase
    {
        public String Name { get; set; }

        public virtual List<Superhero> SuperHeroes { get; set; } 
    }
}
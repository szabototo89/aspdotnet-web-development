using System;
using System.Collections.Generic;
using SuperHeroManager.DataModels.Common;

namespace SuperHeroManager.DataModels.Entities
{
    public class Superhero : EntityBase
    {
        public String Name { get; set; }

        public Boolean IsOnMission { get; set; }

        public virtual List<Skill> Skills { get; set; }

        public virtual List<Team> Teams { get; set; } 
    }
}
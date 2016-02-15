using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SuperHeroManager.DataModels.Common;

namespace SuperHeroManager.DataModels.Superheroes
{
    public class SuperHero : EntityBase
    {
        public String Name { get; set; }

        public Boolean IsOnMission { get; set; }

        public virtual List<Skill> Skills { get; set; }

        public virtual List<Team> Teams { get; set; } 
    }
}
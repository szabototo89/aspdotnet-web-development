using System;
using System.Collections;
using System.Collections.Generic;
using SuperHeroManager.DataModels.Common;

namespace SuperHeroManager.DataModels.Superheroes
{
    public class SuperHero : EntityBase
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public virtual List<Skill> Skills { get; set; }
    }
}
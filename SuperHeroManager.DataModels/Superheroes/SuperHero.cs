using System;
using System.Collections;
using SuperHeroManager.DataModels.Common;

namespace SuperHeroManager.DataModels.Superheroes
{
    public class SuperHero : IEntity
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public IEnumerable<Skill> Skills { get; set; }


    }
}
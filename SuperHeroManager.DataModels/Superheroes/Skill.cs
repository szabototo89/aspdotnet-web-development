using System;
using SuperHeroManager.DataModels.Common;

namespace SuperHeroManager.DataModels.Superheroes
{
    public class Skill : EntityBase
    {
        public String Name { get; set; }

        public String Description { get; set; }
    }
}
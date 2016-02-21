using System;
using System.ComponentModel.DataAnnotations;
using SuperHeroManager.DataModels.Common;

namespace SuperHeroManager.DataModels.Superheroes
{
    public class Skill : EntityBase
    {
        public String Name { get; set; }

        public Int32 Value { get; set; }

        public String Description { get; set; }
    }
}
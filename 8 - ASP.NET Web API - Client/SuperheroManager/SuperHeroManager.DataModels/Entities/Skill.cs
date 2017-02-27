using System;
using SuperHeroManager.DataModels.Common;

namespace SuperHeroManager.DataModels.Entities
{
    public class Skill : EntityBase
    {
        public String Name { get; set; }

        public Int32 Value { get; set; }

        public String Description { get; set; }
    }
}
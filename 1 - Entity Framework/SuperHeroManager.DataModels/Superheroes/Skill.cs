using System;
using System.ComponentModel.DataAnnotations;
using SuperHeroManager.DataModels.Common;

namespace SuperHeroManager.DataModels.Superheroes
{
    public class Skill : EntityBase
    {
        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        [Required]
        public Int32 Value { get; set; }

        [StringLength(500)]
        public String Description { get; set; }
    }
}
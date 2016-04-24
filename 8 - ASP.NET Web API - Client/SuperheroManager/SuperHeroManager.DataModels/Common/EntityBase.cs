using System;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroManager.DataModels.Common
{
    public abstract class EntityBase : IEntity
    {
        [Key]
        public Int32 Id { get; set; }
    }
}
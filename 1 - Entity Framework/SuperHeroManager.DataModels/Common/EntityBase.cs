using System;

namespace SuperHeroManager.DataModels.Common
{
    public abstract class EntityBase: IEntity
    {
        public Int32 Id { get; set; }
    }
}
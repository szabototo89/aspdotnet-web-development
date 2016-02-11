using System;
using System.Data.Entity;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperHeroManager.DataModels.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("MySuperheroDatabase")
        {
            
        }

        public DbSet<SuperHero> Superheroes { get; set; }

        public DbSet<Skill> Skills { get; set; } 
    }
}
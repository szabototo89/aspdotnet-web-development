using System;
using System.Data.Entity;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperHeroManager.DataModels.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(String nameOrConnectionString) 
            : base(nameOrConnectionString)
        {
        }

        public DbSet<SuperHero> Superheroes { get; set; }
    }
}
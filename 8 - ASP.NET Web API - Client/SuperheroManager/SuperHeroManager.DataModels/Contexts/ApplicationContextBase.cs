using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using SuperHeroManager.DataModels.Entities;

namespace SuperHeroManager.DataModels.Contexts
{
    public abstract class ApplicationContextBase : DbContext
    {
        protected ApplicationContextBase(String nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        public DbSet<Superhero> Superheroes { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
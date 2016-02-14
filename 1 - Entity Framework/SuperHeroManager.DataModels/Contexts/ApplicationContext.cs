using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
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

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //base.OnModelCreating(modelBuilder);

      var superheroConfiguration = modelBuilder.Entity<SuperHero>();

      superheroConfiguration.HasMany(hero => hero.Teams)
                            .WithMany(team => team.SuperHeroes);

      superheroConfiguration.HasMany(hero => hero.Skills);
      superheroConfiguration.HasKey(hero => hero.Id);
      superheroConfiguration.HasRequired(hero => hero.Name);

      superheroConfiguration
        .Property(hero => hero.IsOnMission)
        .HasColumnName("is_on_mission");
    }
  }
}
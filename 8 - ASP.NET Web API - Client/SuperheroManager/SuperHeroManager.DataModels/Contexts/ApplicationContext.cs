using System.Data.Entity;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperHeroManager.DataModels.Contexts
{
  public class ApplicationContext : ApplicationContextBase
  {
    public ApplicationContext() : base("MyCurrentSuperheroDatabase")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      var superheroConfiguration = modelBuilder.Entity<Superhero>();

      superheroConfiguration.HasMany(hero => hero.Teams)
                            .WithMany(team => team.SuperHeroes);

      superheroConfiguration.HasMany(hero => hero.Skills);
      superheroConfiguration.HasKey(hero => hero.Id);
    }
  }
}
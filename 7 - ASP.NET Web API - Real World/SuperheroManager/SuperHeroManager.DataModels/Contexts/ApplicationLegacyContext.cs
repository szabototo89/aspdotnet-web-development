using System.Data.Entity;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperHeroManager.DataModels.Contexts
{
  public class ApplicationLegacyContext : ApplicationContextBase
  {
    public ApplicationLegacyContext() : base("MyLegacySuperheroDatabase")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      var superheroConfiguration = modelBuilder.Entity<Superhero>();

      superheroConfiguration.HasMany(hero => hero.Teams)
                            .WithMany(team => team.SuperHeroes);

      superheroConfiguration.HasMany(hero => hero.Skills);
      superheroConfiguration.HasKey(hero => hero.Id);

      var skillConfiguration = modelBuilder.Entity<Skill>();
      skillConfiguration.Property(skill => skill.Name)
                        .HasColumnName("skill_name")
                        .HasMaxLength(50);

      skillConfiguration.Property(skill => skill.Description)
                        .HasColumnName("skill_description")
                        .HasMaxLength(500);

      skillConfiguration.Property(skill => skill.Value)
                        .HasColumnName("strength_power");
    }
  }
}
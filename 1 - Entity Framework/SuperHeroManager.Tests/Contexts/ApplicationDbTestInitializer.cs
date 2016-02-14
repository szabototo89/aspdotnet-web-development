using System.Collections.Generic;
using System.Data.Entity;
using SuperHeroManager.DataModels.Contexts;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperHeroManager.Tests.Contexts
{
  public class ApplicationDbTestInitializer : DropCreateDatabaseAlways<ApplicationContext>
  {
    protected override void Seed(ApplicationContext context)
    {
      var justiceLeague = new Team
      {
        Name = "Justice League",
      };

      var batman = new SuperHero
      {
        Name = "Batman",
        Skills = new List<Skill>
        {
          new Skill
          {
            Name = "Ninjutsu",
            Description = "Professional in several martial arts. ",
            Value = 10
          },
          new Skill
          {
            Name="Detective",
            Description = "",
            Value = 10
          }
        },
        Teams = new List<Team> { justiceLeague }
      };

      justiceLeague.SuperHeroes = new List<SuperHero> { batman };

      context.Superheroes.Add(batman);

      // saving the changes back into the database
      context.SaveChanges();
    }
  }
}
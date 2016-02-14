using System.Collections.Generic;
using System.Data.Entity;
using SuperHeroManager.DataModels.Contexts;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperHeroManager.Tests.Contexts
{
  public class ApplicationDbTestInitializer<TContext> : DropCreateDatabaseAlways<TContext>
    where TContext: ApplicationContextBase
  {
    protected override void Seed(TContext contextBase)
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

      contextBase.Superheroes.Add(batman);

      // saving the changes back into the database
      contextBase.SaveChanges();
    }
  }
}
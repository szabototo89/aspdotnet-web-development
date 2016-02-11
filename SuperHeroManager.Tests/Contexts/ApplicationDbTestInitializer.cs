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
            var batmanSkills = new[]
            {
                new Skill() {Name = "Ninjutsu", Description = "Professional in several martial arts. "}
            };

            var superheroes = new[]
            {
                new SuperHero()
                {
                    Name = "Batman",
                    Skills = new List<Skill>(batmanSkills)
                },
            };

            context.Superheroes.AddRange(superheroes);
            context.SaveChanges();
        }
    }
}
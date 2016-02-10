using System.Data.Entity;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperHeroManager.DataModels.Contexts
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var superheroes = new[]
            {
                new SuperHero()
                {
                    Name = "Batman",
                    Skills = new[]
                    {
                        new Skill() {Name = "Ninjutsu", Description = "Professional in several martial arts. "}
                    }
                },
            };

            context.Superheroes.AddRange(superheroes);
            context.SaveChanges();
        }
    }
}
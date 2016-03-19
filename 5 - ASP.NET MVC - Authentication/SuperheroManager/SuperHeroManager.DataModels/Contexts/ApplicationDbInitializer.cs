using System.Collections.Generic;
using System.Data.Entity;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperHeroManager.DataModels.Contexts
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContextBase>
    {
        protected override void Seed(ApplicationContextBase contextBase)
        {
            var superheroes = new[]
            {
                new Superhero()
                {
                    Name = "Batman",
                    Skills = new List<Skill>(new[]
                    {
                        new Skill
                        {
                            Name = "Ninjutsu",
                            Description = "Professional in several martial arts. "
                        }
                    })
                },
            };

            contextBase.Superheroes.AddRange(superheroes);
            contextBase.SaveChanges();
        }
    }
}
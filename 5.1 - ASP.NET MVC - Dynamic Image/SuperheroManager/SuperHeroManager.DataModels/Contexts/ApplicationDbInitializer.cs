using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperHeroManager.DataModels.Contexts
{
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationContextBase>
    {
        protected override void Seed(ApplicationContextBase contextBase)
        {
            var stream = new MemoryStream();
            var image = Image.FromFile("G:\\Images\\635820032054432675-314366847_403b8f3f4eeed5389925a9fc5c0b5b2d.jpg");
            image.Save(stream, ImageFormat.MemoryBmp);

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
                    }),
                    Image = stream.ToArray()
                },
            };

            contextBase.Superheroes.AddRange(superheroes);
            contextBase.SaveChanges();
        }
    }
}
using System.Data.Entity;
using System.Linq;
using NUnit.Framework;
using SuperHeroManager.DataModels.Contexts;

namespace SuperHeroManager.Tests.Contexts
{
  [TestFixture]
  public class ApplicationContextTests
  {
    [TearDown]
    public void Teardown()
    {
      Database.SetInitializer<DbContext>(null);
    }

    [Test(Description = "ApplicationContext should connect to database successfully when local connection has been specified")]
    public void ApplicationContext_ShouldConnectToDatabaseSuccessfully_WhenLocalConnectionHasBeenSpecified()
    {
      // Arrange
      var underTest = new ApplicationContext();
      Database.SetInitializer(new ApplicationDbTestInitializer<ApplicationContext>());

      // Act
      var result = underTest.Superheroes.SingleOrDefault();

      // Assert
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Name, Is.EqualTo("Batman"));
      Assert.That(result.Skills.Count, Is.EqualTo(2));
    }

    [Test(Description = "ApplicationLegacyContext should connect to database successfully when local connection has been specified")]
    public void ApplicationLegacyContext_ShouldConnectToDatabaseSuccessfully_WhenLocalConnectionHasBeenSpecified()
    {
      // Arrange
      var underTest = new ApplicationLegacyContext();
      Database.SetInitializer(new ApplicationDbTestInitializer<ApplicationLegacyContext>());

      // Act
      var superHeroes = underTest.Superheroes;
      var result = superHeroes.SingleOrDefault();

      // Assert
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Name, Is.EqualTo("Batman"));
      Assert.That(result.Skills.Count, Is.EqualTo(2));
    }

  }
}
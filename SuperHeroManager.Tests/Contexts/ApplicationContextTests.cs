using System.Linq;
using NUnit.Framework;
using SuperHeroManager.DataModels.Contexts;

namespace SuperHeroManager.Tests.Contexts
{
    [TestFixture]
    public class ApplicationContextTests
    {
        [Test(Description = "ApplicationContext should connect to database successfully when local connection has been specified")]
        public void ApplicationContext_ShouldConnectToDatabaseSuccessfully_WhenLocalConnectionHasBeenSpecified()
        {
            // Arrange
            var connectionString = "";
            var underTest = new ApplicationContext(connectionString);

            // Act
            var result = underTest.Superheroes.ToList();

            // Assert
            Assert.That(result, Is.Not.Empty);
        }
    }
}
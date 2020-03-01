using Ninject;
using NUnit.Framework;
using TacitusLogger.DI.Ninject;

namespace TacitusLogger.DI.NinjectDI.IntegrationTests
{
    [TestFixture]
    public class TacitusLoggerExtensionsForNinjectTests
    {
        [Test]
        public void When_Logger_Is_Not_Built_Ninject_Kernel_Does_Not_Have_ILogger_Binding()
        {
            // Arrange
            IKernel kernel = new StandardKernel();
            var loggerBuilder = kernel.TacitusLogger("logger1");

            // Assert
            Assert.Catch<ActivationException>(() =>
            {
                kernel.Get<ILogger>();
            });
        }

        [Test]
        public void When_Logger_Is_Built_Ninject_Kernel_Has_ILogger_Binding()
        {
            // Arrange
            IKernel kernel = new StandardKernel();
            var loggerBuilder = kernel.TacitusLogger("logger1");
            loggerBuilder.BuildLogger();

            // Act 
            ILogger logger = kernel.Get<ILogger>();

            // Assert
            Assert.IsNotNull(logger);
            Assert.IsInstanceOf<Logger>(logger);
        }

        [Test]
        public void ILogger_Binding_Is_Singleton()
        {
            // Arrange
            IKernel kernel = new StandardKernel();
            ILogger loggerFromBuilder = kernel.TacitusLogger("logger1").BuildLogger();

            // Act 
            ILogger loggerInstance1 = kernel.Get<ILogger>();
            ILogger loggerInstance2 = kernel.Get<ILogger>();
            ILogger loggerInstance3 = kernel.Get<ILogger>();

            // Assert
            Assert.AreEqual(loggerFromBuilder, loggerInstance1);
            Assert.AreEqual(loggerFromBuilder, loggerInstance2);
            Assert.AreEqual(loggerFromBuilder, loggerInstance3);
        }
    }
}

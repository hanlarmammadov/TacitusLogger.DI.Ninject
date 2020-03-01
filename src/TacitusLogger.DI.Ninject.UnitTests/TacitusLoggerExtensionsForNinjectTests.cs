using Moq;
using Ninject;
using Ninject.Syntax;
using NUnit.Framework;
using TacitusLogger.Builders;
using TacitusLogger.DI.Ninject;

namespace TacitusLogger.DI.NinjectDI.UnitTests
{
    [TestFixture]
    public class TacitusLoggerExtensionsForNinjectTests
    {
        [Test]
        public void TacitusLogger_Taking_Ninject_Kernel_And_Logger_Name_When_Called_Sets_LoggerName()
        {
            // Arrange 
            string loggerName = "logger1";

            // Act
            var loggerBuilder = (CustomizedLoggerBuilder)TacitusLogger.DI.Ninject.TacitusLoggerExtensionsForNinject.TacitusLogger(new Mock<IKernel>().Object, loggerName);

            // Assert 
            Assert.AreEqual(loggerName, loggerBuilder.LoggerName);
        }

        [Test]
        public void TacitusLogger_Taking_Ninject_Kernel_And_Logger_Name()
        {
            // Arrange
            var ninjectKernelMock = new Mock<IKernel>();
            var bindingToSyntaxMock = new Mock<IBindingToSyntax<ILogger>>();
            ninjectKernelMock.Setup(x => x.Bind<ILogger>()).Returns(bindingToSyntaxMock.Object);

            // Act
            var loggerBuilder = (CustomizedLoggerBuilder)TacitusLoggerExtensionsForNinject.TacitusLogger(ninjectKernelMock.Object, "logger1");

            // Assert  
            ninjectKernelMock.Verify(x => x.Bind<ILogger>(), Times.Never);
            bindingToSyntaxMock.Verify(x => x.ToConstant(It.IsAny<ILogger>()), Times.Never);
            var logger = loggerBuilder.BuildLogger();
            ninjectKernelMock.Verify(x => x.Bind<ILogger>(), Times.Once);
            bindingToSyntaxMock.Verify(x => x.ToConstant(logger), Times.Once);
        }

        [Test]
        public void TacitusLogger_Taking_Ninject_Kernel_When_Called_Sets_Default_LoggerName()
        {
            // Act
            var loggerBuilder = (CustomizedLoggerBuilder)TacitusLoggerExtensionsForNinject.TacitusLogger(new Mock<IKernel>().Object);

            // Assert 
            Assert.NotNull(loggerBuilder.LoggerName);
        }

        [Test]
        public void TacitusLogger_Taking_Ninject_Kernel()
        {
            // Arrange
            var ninjectKernelMock = new Mock<IKernel>();
            var bindingToSyntaxMock = new Mock<IBindingToSyntax<ILogger>>();
            ninjectKernelMock.Setup(x => x.Bind<ILogger>()).Returns(bindingToSyntaxMock.Object);

            // Act
            var loggerBuilder = (CustomizedLoggerBuilder)TacitusLoggerExtensionsForNinject.TacitusLogger(ninjectKernelMock.Object);

            // Assert  
            ninjectKernelMock.Verify(x => x.Bind<ILogger>(), Times.Never);
            bindingToSyntaxMock.Verify(x => x.ToConstant(It.IsAny<ILogger>()), Times.Never);
            var logger = loggerBuilder.BuildLogger();
            ninjectKernelMock.Verify(x => x.Bind<ILogger>(), Times.Once);
            bindingToSyntaxMock.Verify(x => x.ToConstant(logger), Times.Once);
        }
    }
}

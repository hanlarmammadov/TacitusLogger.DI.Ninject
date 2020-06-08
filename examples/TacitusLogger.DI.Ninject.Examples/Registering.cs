using Ninject;
using TacitusLogger.Builders;

namespace TacitusLogger.DI.Ninject.Examples
{
    class Registering
    {
        public void Registering_Logger_With_Ninject()
        {
            IKernel kernel = new StandardKernel();
            // Registering TacitusLogger with Ninject as a singleton.
            kernel.TacitusLogger("logger1").ForAllLogs()
                                           .Console()
                                           .Add()
                                           .BuildLogger();
            // Resolving the dependency
            ILogger logger = kernel.Get<ILogger>();
        }
        public void Registering_Logger_With_Ninject2()
        {
            IKernel kernel = new StandardKernel();
            // Registering TacitusLogger with Ninject as a singleton.
            var loggerBuilder = kernel.TacitusLogger("logger1");
            loggerBuilder.ForAllLogs()
                         .Console()
                         .Add()
                         .BuildLogger();

            // Resolving the dependency
            ILogger logger = kernel.Get<ILogger>();
        }
    }
}

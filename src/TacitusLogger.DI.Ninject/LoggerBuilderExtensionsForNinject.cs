using Ninject;
using TacitusLogger.Builders;

namespace TacitusLogger.DI.Ninject
{
    public static class TacitusLoggerExtensionsForNinject
    {
        public static ILoggerBuilder TacitusLogger(this IKernel kernel, string loggerName)
        {
            return new CustomizedLoggerBuilder(loggerName, null, (lg) => kernel.Bind<ILogger>().ToConstant(lg));
        }
        public static ILoggerBuilder TacitusLogger(this IKernel kernel)
        {
            return TacitusLogger(kernel, null);
        }
    }
}

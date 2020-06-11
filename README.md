# TacitusLogger.DI.Ninject

> Extension for Ninject dependency injection container that helps to configure and add TacitusLogger as a singleton.
 
Dependencies:  
* NET Standard >= 2.0   
* Ninject >= 3.3.0   
* TacitusLogger >= 0.3.0  
  
> Attention: `TacitusLogger.DI.Ninject` is currently in **Alpha phase**. This means you should not use it in any production code.

## Installation

The NuGet <a href="https://www.nuget.org/packages/TacitusLogger.DI.Ninject" target="_blank">package</a>:

```powershell
PM> Install-Package TacitusLogger.DI.Ninject
```

## Examples

### 
```cs
IKernel kernel = new StandardKernel();
// Registering TacitusLogger with Ninject as a singleton.
kernel.TacitusLogger("logger1").ForAllLogs()
                               .Console()
                               .Add()
                               .BuildLogger();
// Resolving the dependency
ILogger logger = kernel.Get<ILogger>();
```
Or:

```cs
IKernel kernel = new StandardKernel();
// Registering TacitusLogger with Ninject as a singleton.
var loggerBuilder = kernel.TacitusLogger("logger1");
loggerBuilder.ForAllLogs()
             .Console()
             .Add()
             .BuildLogger();

// Resolving the dependency
ILogger logger = kernel.Get<ILogger>();
```
---


## License

[APACHE LICENSE 2.0](https://www.apache.org/licenses/LICENSE-2.0)

## See also

TacitusLogger:  

- [TacitusLogger](https://github.com/khanlarmammadov/TacitusLogger) - A simple yet powerful .NET logging library.

Destinations:

- [TacitusLogger.Destinations.MongoDb](https://github.com/khanlarmammadov/TacitusLogger.Destinations.MongoDb) - Extension destination for TacitusLogger that sends logs to MongoDb database.
- [TacitusLogger.Destinations.RabbitMq](https://github.com/khanlarmammadov/TacitusLogger.Destinations.RabbitMq) - Extension destination for TacitusLogger that sends logs to the RabbitMQ exchanges.
- [TacitusLogger.Destinations.Email](https://github.com/khanlarmammadov/TacitusLogger.Destinations.Email) - Extension destination for TacitusLogger that sends logs as emails using SMTP protocol.
- [TacitusLogger.Destinations.EntityFramework](https://github.com/khanlarmammadov/TacitusLogger.Destinations.EntityFramework) - Extension destination for TacitusLogger that sends logs to database using Entity Framework ORM.
- [TacitusLogger.Destinations.Trace](https://github.com/khanlarmammadov/TacitusLogger.Destinations.Trace) - Extension destination for TacitusLogger that sends logs to System.Diagnostics.Trace listeners.  
  
Dependency injection:

- [TacitusLogger.DI.Autofac](https://github.com/khanlarmammadov/TacitusLogger.DI.Autofac) - Extension for Autofac dependency injection container that helps to configure and add TacitusLogger as a singleton.
- [TacitusLogger.DI.MicrosoftDI](https://github.com/khanlarmammadov/TacitusLogger.DI.MicrosoftDI) - Extension for Microsoft dependency injection container that helps to configure and add TacitusLogger as a singleton.  

Log contributors:

- [TacitusLogger.Contributors.ThreadInfo](https://github.com/khanlarmammadov/TacitusLogger.Contributors.ThreadInfo) - Extension contributor for TacitusLogger that generates additional info related to the thread on which the logger method was called.
- [TacitusLogger.Contributors.MachineInfo](https://github.com/khanlarmammadov/TacitusLogger.Contributors.MachineInfo) - Extension contributor for TacitusLogger that generates additional info related to the machine on which the log was produced.
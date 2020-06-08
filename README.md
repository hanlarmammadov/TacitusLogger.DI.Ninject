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

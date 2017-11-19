# Log4Net.Demystifier
Unmangle the names of async and iterator methods in exception stack traces using @benaadams's [Demystifier](https://github.com/benaadams/Ben.Demystifier) via custom LogManager which wraps your ILog.

# How to install/Configure?

Install from nuget:

```powershell
Install-Package Log4Net.Demystifier
```

Configure via your favourite DI container.
For example in StructureMap:

```csharp
For<ILog>().Use(DemystifiedLogManager.GetLogger("AppLogger"));
```

Demystify log manager would wrap your logger via demystifier logger.

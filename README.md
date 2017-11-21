# Log4Net.Demystifier [![NuGet Pre Release](https://buildstats.info/nuget/Log4Net.Demystifier?includePreReleases=true)](https://www.nuget.org/packages/Log4Net.Demystifier)
Unmangle the names of async and iterator methods in exception stack traces using @benaadams's [Demystifier](https://github.com/benaadams/Ben.Demystifier) via custom LogManager which wraps your ILog.

# How to Install/Configure?

Install from nuget:

```powershell
Install-Package Log4Net.Demystifier
```

Configure via your favourite DI container.
For example in StructureMap:

```csharp
For<ILog>().Use(DemystifiedLogManager.GetLogger("AppLogger"));
```

Demystify log manager would wrap your logger via demystified logger.

# Troubleshooting

If you encounter problem in old csproj based project(s), because of [referencing .net standard library to a .net framework base project](https://github.com/dotnet/standard/issues/410).
You have to:
1. add `RestoreProjectStyle` element to csproj

```xml
<PropertyGroup>
  <RestoreProjectStyle>PackageReference</RestoreProjectStyle>
</PropertyGroup>
```
2. Delete packages.config from your project and uninstall all packages
3. Install all packages one more time
4. If you encounter such error: `error : The project.json is referencing the project 'YourProject.csproj', but an output path was not specified on an item in the ProjectReferencesCreatingPackages property.` you have to update Visual Studio to > 15.2
5. If you project linking a file from packages folder like this:
```xml
<Content Include="..\packages\package.1.0.0.1\some.file">
  <Link>some.file</Link>
  <CopyToOutputDirectory>Always</CopyToOutputDirectory>
</Content>
```
It should be replaced to something like this:
```xml
<Content Include="$(NuGetPackageFolders)\package\1.0.0.1\some.file">
  <Link>some.file</Link>
  <CopyToOutputDirectory>Always</CopyToOutputDirectory>
</Content>
```

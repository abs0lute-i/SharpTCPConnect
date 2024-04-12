# SharpTCPConnect
CSharp implementation of TCP connect. Mainly useful in scenarios where you need .NET instead of a BOF (beacon).

Either build with VS or dotnet CLI : 

```dotnet publish /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:IncludeAllContentForSelfExtract=true --self-contained true```
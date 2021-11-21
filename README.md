# ecs-protobuf-csharp-01


The nuget package source needs to be configured within the Visual Studio IDE

Name: protobuf-csharp

Source: https://gitlab.com/api/v4/projects/31452783/packages/nuget/index.json


If asked for creditials you might need to configure nuget package access details through the following file:

> %USERPROFILE%\AppData\Roaming\NuGet\NuGet.Config

Or within the startup project of the visual studio solution:

> ./Properties/nuget.config

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
    <add key="common-lib" value="https://gitlab.com/api/v4/projects/26570197/packages/nuget/index.json" />
    <add key="protobuf-csharp" value="https://gitlab.com/api/v4/projects/31452783/packages/nuget/index.json" />
  </packageSources>
  <packageRestore>
    <add key="enabled" value="True" />
    <add key="automatic" value="True" />
  </packageRestore>
  <bindingRedirects>
    <add key="skip" value="False" />
  </bindingRedirects>
  <packageManagement>
    <add key="format" value="0" />
    <add key="disabled" value="False" />
  </packageManagement>
  <packageSourceCredentials>
    <common-lib>
        <add key="Username" value="-insert-username-here-" />
        <add key="ClearTextPassword" value="-insert-password-here-" />
    </common-lib>
    <protobuf-csharp>
        <add key="Username" value="-insert-username-here-" />
        <add key="ClearTextPassword" value="-insert-password-here-" />
    </protobuf-csharp>
  </packageSourceCredentials>
</configuration>
```


> Both the identity-svc and solutions-fulfilment-svc gRPC services should be running locally on the development machine.

Returned Results should look roughly the following (last updated 2021-11-19):

```
{
  "PricingModelGuid": "00000000-0000-0000-0000-000000000000",
  "Title": "Testing...",
  "Synopsis": "Some testing text...",
  "HtmlContent": "\u003Cdiv\u003EHeylo World\u003C/div\u003E",
  "Iso4217Code": "EUR",
  "SalesValue": 2345
}
 --------[ next service request ]--------
{
  "Message": "Heylo World 01 [start]"
}
{
  "Message": "Heylo World 02"
}
{
  "Message": "Heylo World 03 [ end ]"
}
{
  "Message": "Default"
}

```

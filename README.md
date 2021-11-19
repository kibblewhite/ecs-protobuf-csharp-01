# ecs-protobuf-csharp-01


The nuget package source needs to be configured within the Visual Studio IDE

Name: protobuf-csharp

Source: https://gitlab.com/api/v4/projects/31452783/packages/nuget/index.json


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

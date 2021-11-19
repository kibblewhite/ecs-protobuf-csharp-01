using ECS.DTO.v1.Identity.Request;
using ECS.DTO.v1.SolutionsFulfilment.Request;
using ECS.Services.v1.Identity;
using ECS.Services.v1.SolutionsFulfilment;
using Grpc.Net.Client;
using System.Text.Json;


var opt = new JsonSerializerOptions() { WriteIndented = true };

var http_handler_01 = new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
};

using var channel_01 = GrpcChannel.ForAddress("https://solutions-fulfilment-svc:32443", new GrpcChannelOptions { HttpHandler = http_handler_01 });

var client_01 = new ClientPlan.ClientPlanClient(channel_01);

var request_01 = new ListAllClientPlansRequest();

var response_01 = await client_01.ListAllClientPlansAsync(request_01);

var data_01 = response_01.Result.Data;

foreach (var data in data_01)
{
    string data_str_json = JsonSerializer.Serialize(data, opt);
    Console.WriteLine(data_str_json);
}

Console.WriteLine(" --------[ next service request ]-------- ");

var http_handler_02 = new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
};

using var channel_02 = GrpcChannel.ForAddress("https://identity-svc:31443", new GrpcChannelOptions { HttpHandler = http_handler_02 });

var client_02 = new Greeter.GreeterClient(channel_02);

var request_02 = new HelloRequest();

var response_02 = await client_02.SayHelloAsync(request_02);

var data_02 = response_02.Result.Data;

foreach (var data in data_02)
{
    string data_str_json = JsonSerializer.Serialize(data, opt);
    Console.WriteLine(data_str_json);
}

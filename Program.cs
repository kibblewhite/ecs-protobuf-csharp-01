namespace ecs_protobuf_csharp_01;

public class Program
{

    public static void Main(string[] args)
    {
        MainAsync(args).GetAwaiter().GetResult();
    }

    public static async Task MainAsync(string[] args)
    {

        var opt = new JsonSerializerOptions() { WriteIndented = true };

        Console.WriteLine(" --------[ first service request ]-------- ");

        HttpClientHandler http_handler_01 = new()
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };

        using GrpcChannel channel_01 = GrpcChannel.ForAddress("https://solutions-fulfilment-svc:32443", new GrpcChannelOptions { HttpHandler = http_handler_01 });

        ClientPlan.ClientPlanClient client_01 = new(channel_01);

        ListAllClientPlansRequest request_01 = new();

        try
        {
            var response_01 = await client_01.ListAllClientPlansAsync(request_01);
            var data_01 = response_01.Result.Data;
            foreach (var data in data_01)
            {
                string data_str_json = JsonSerializer.Serialize(data, opt);
                Console.WriteLine(data_str_json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine(" --------[ next service request ]-------- ");

        HttpClientHandler http_handler_02 = new()
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };

        using GrpcChannel channel_02 = GrpcChannel.ForAddress("https://identity-svc:31443", new GrpcChannelOptions { HttpHandler = http_handler_02 });

        Greeter.GreeterClient client_02 = new(channel_02);

        HelloRequest request_02 = new();

        try
        {
            var response_02 = await client_02.SayHelloAsync(request_02);
            var data_02 = response_02.Result.Data;
            foreach (var data in data_02)
            {
                string data_str_json = JsonSerializer.Serialize(data, opt);
                Console.WriteLine(data_str_json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine(" --------[ last service request with certification authentication ]-------- ");

        X509Certificate2? x509_certificate = new("Infrastructure\\pass_cert.p12", "development-password");
        ArgumentNullException.ThrowIfNull(x509_certificate, nameof(x509_certificate));
        string certificate_raw_data = x509_certificate.GetRawCertDataString();

        CallOptions call_options = new(new Metadata
        {   // note (2021-11-21|kibble): this is for the service certificate authentication / when the client requires access to particular services when a client is without a JWT
            new Metadata.Entry("Authorization", $"Certificate {certificate_raw_data}")
        });

        HttpClientHandler http_handler_03 = new()
        {
            // todo (2021-11-21|kibble): Rather that dismiss any dangerous server ssl certificates, make sure to include the real certificate in the future and lock this down security wise!
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };

        using GrpcChannel channel_03 = GrpcChannel.ForAddress("https://solutions-fulfilment-svc:32443", new GrpcChannelOptions { HttpHandler = http_handler_02 });
        ArgumentNullException.ThrowIfNull(channel_03, nameof(channel_03));

        PriceModel.PriceModelClient? client_03 = new(channel_03);
        ArgumentNullException.ThrowIfNull(client_03, nameof(client_03));

        try
        {
            ListAllPriceModelsRequest request_03 = new();
            ListAllPriceModelsResponse? response_03 = await client_03.ListAllPriceModelsAsync(request_03, call_options);
            ArgumentNullException.ThrowIfNull(response_03, nameof(response_03));

            var data_03 = response_03.Result.Data;
            foreach (var data in data_03)
            {
                string data_str_json = JsonSerializer.Serialize(data, opt);
                Console.WriteLine(data_str_json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();
    }

}

using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Clients.Builder;
using Gizmo.Web.Api.Models;

using MessagePack;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

var host = CreateHostBuilder(args).Build();

try
{
    var ordersClient = host.Services.GetRequiredService<OrdersWebApiClient>();
    var hostsClient = host.Services.GetRequiredService<HostWebApiClient>();

    //var getResults = await hostsClient.GetAsync(new HostsFilter { Pagination = new() { Limit = 2 }});
    var get2Results = await ordersClient.CalculateUserOrderPriceAsync(1, new OrderCalculateModelOptions() 
    { 
        OrderLines = new List<OrderLineModelOptions> 
        { 
            new() 
            {
                CustomPrice = 42 
            },
            new()
            {
                CustomPrice = 44,
                Product = new ProductLineModel()
                {
                    ProductId = 2
                }
            }
        }
    });
    var createResult = await ordersClient.CreateUserOrderAsync(1, new());
    var updateResult = await ordersClient.SetOrderLineDeliveredQuantityAsync(1,2,new());
    var deleteResult = await ordersClient.InvoiceOrderAsync(1);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
    .ConfigureLogging(p => p.ClearProviders())
      .ConfigureServices((_, services) =>
      {
          services.AddLogging(opt =>
          {
              opt.SetMinimumLevel(LogLevel.Warning);
              opt.AddConsole();
          });

          services.AddHttpClient("secure", httpClient =>
           {
               var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("admin:admin"));

               httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
               httpClient.BaseAddress = new Uri("http://localhost:80");
           })
          .ConfigureHttpClient(__ => { })
          .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
          {
              ServerCertificateCustomValidationCallback = (_, _, _, _) => true
          });

          services.AddWebApiClient("secure", _ => { })
          .WithMessagePackSerialization(options =>
          {
              options.MessagePackSerializerOptions = MessagePackSerializerOptions.Standard
              .WithResolver(MessagePack.Resolvers.StandardResolver.Instance)
              .WithSecurity(MessagePackSecurity.UntrustedData);
          });
          //.WithJsonSerialization(options =>
          //{
          //    options.JsonSerializerOptions.AllowTrailingCommas = true;
          //    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
          //});
      });

using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Clients.Builder;
using Gizmo.Web.Api.Models;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = CreateHostBuilder(args).Build();

try
{
    var usersClient = host.Services.GetRequiredService<UsersWebApiClient>();

    UsersFilter filter = new() { Pagination = new() { Limit = 5, Cursor = new() { IsForward = false, Name = "sex" } } };
    PagedList<UserModel> result = new(Enumerable.Empty<UserModel>());

    result.SetCursor(filter);
    result = await usersClient.GetAsync(filter);

    result.SetCursor(filter);
    result = await usersClient.GetAsync(filter);

    result.SetCursor(filter);
    result = await usersClient.GetAsync(filter);
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
          //.WithMessagePackSerialization(options =>
          //{
          //    options.MessagePackSerializerOptions = MessagePackSerializerOptions.Standard
          //    .WithResolver(MessagePack.Resolvers.StandardResolver.Instance)
          //    .WithSecurity(MessagePackSecurity.UntrustedData);
          //});
          .WithJsonSerialization(options =>
          {
              options.JsonSerializerOptions.AllowTrailingCommas = true;
              options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
          });
      });

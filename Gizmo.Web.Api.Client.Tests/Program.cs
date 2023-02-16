using System;
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

    //// Start pulling data sorted by Id in ascending order
    //PaginationCursor usersCursor = null;
    //// Start pulling data sorted by Sex column (property) in ascending order
    //PaginationCursor usersCursor = new() { Name = "sex" };
    //// Start pulling data sorted by BirthDate column (property) in ascending order
    //PaginationCursor usersCursor = new() { Name = "birthdate" };
    //// Start pulling data sorted by Id column (property) in descending order
    //PaginationCursor usersCursor = new() { Id = int.MaxValue, Name = "id", IsForward = false };
    // Start pulling data sorted by Sex column (property) in descending order
    //PaginationCursor usersFilterCursor = new() { Id = int.MaxValue, Name = "sex", IsForward = false };
    
    //Configuring filter for the request
    UsersFilter filter = new() { Pagination = new() { Limit = 5, Cursor = new() { Name = "id" } } };

    // Getting the first data chunk
    var chunk_1 = await usersClient.GetAsync(filter);

    // When needs the next data chunk
    chunk_1.SetNextCursor(filter);

    // Getting the next data chunk
    var chunk_2 = await usersClient.GetAsync(filter);

    // When needs the previous data chunk
    chunk_2.SetPrevCursor(filter);

    // Getting the previous data chunk
    var chunk_3 = await usersClient.GetAsync(filter);
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

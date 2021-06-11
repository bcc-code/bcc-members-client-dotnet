using System;
using System.Net.Http;
using System.Net.Http.Headers;
using BccMembers.Api.Client;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class ServiceInstaller
  {
    public static IServiceCollection ConfigureBccMembersClient(this IServiceCollection services, string apiUrl, string apiKey)
    {
      services.AddHttpClient("BccMembersApiClient", httpClient =>
      {
        httpClient.BaseAddress = new Uri(apiUrl);
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add("x-access-token", apiKey);
      });

      return services.AddTransient<IBccMembersApiClient>(x =>
      {
        var clientFactory = x.GetRequiredService<IHttpClientFactory>();
        var httpClient = clientFactory.CreateClient("BccMembersApiClient");

        return new BccMembersApiClient(httpClient);
      });
    }
  }
}

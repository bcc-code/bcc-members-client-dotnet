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
            return services.AddTransient<IBccMembersApiClient>(x =>
            {
                var clientFactory = x.GetRequiredService<IHttpClientFactory>();
                var apiClient = new ApiHttpClient(clientFactory, new BccMembersApiClientOptions
                {
                    ApiBasePath = apiUrl,
                    ApiKey = apiKey
                });
                return new BccMembersApiClient(apiClient);
            });
        }

        public static IServiceCollection ConfigureBccMembersClient(this IServiceCollection services, BccMembersApiClientOptions options)
        {
            return services.AddTransient<IBccMembersApiClient>(x =>
            {
                var clientFactory = x.GetRequiredService<IHttpClientFactory>();
                var apiClient = new ApiHttpClient(clientFactory, options);
                return new BccMembersApiClient(apiClient);
            });
        }

    }
}

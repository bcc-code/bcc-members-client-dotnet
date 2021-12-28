using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace BccMembers.Api.Client.Tests
{

    public class ApiTestFixture : IDisposable
    {
        private IConfiguration _configuration;

        public ApiTestFixture()
        {
            Configuration = ConfigHelper.GetIConfigurationRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var clientFactory = new HttpClientFactory();
            var options = Configuration.GetSection("BccMembersApi").Get<BccMembersApiClientOptions>();
            ApiClient = new BccMembersApiClient(new ApiHttpClient(clientFactory, options));
        }

        public IConfiguration Configuration { get; }
        public IBccMembersApiClient ApiClient { get; }

        public IBccMembersApiClient CreateClient(BccMembersApiClientOptions options) => new BccMembersApiClient(new ApiHttpClient(new HttpClientFactory(), options));

        public void Dispose()
        {
        }
    }

    public class MembersApiTests : IClassFixture<ApiTestFixture>
    {

        public MembersApiTests(ApiTestFixture fixture)
        {
            Fixture = fixture;
        }

        public ApiTestFixture Fixture { get; }
        public IConfiguration Configuration => Fixture.Configuration;
        public IBccMembersApiClient ApiClient => Fixture.ApiClient;

        [Fact]
        public async void Test1()
        {
            var member = await ApiClient.GetPersonAsync(13629);
        }
    }
}

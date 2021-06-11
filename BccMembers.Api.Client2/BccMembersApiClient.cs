using System.Net.Http;
using System.Threading.Tasks;
using BccMembers.Api.Client.Contracts;
using BccMembers.Api.Client.Extensions;

namespace BccMembers.Api.Client
{
    internal class BccMembersApiClient : IBccMembersApiClient
    {
        private readonly HttpClient httpClient;

        public BccMembersApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<BccPerson> GetPersonAsync(int id)
        {
            string url = $"person/{id}";

            return this.httpClient.GetAsync<BccPerson>(url);
        }
    }
}

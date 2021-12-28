using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BccMembers.Api.Client.Contracts;

[assembly: InternalsVisibleTo("BccMembers.Api.Client.Tests")]

namespace BccMembers.Api.Client
{

    internal class BccMembersApiClient : IBccMembersApiClient
    {
        private readonly ApiHttpClient httpClient;

        public BccMembersApiClient(ApiHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<BccPerson> GetPersonAsync(int personId)
        {
            string url = $"person?personID={personId}";

            PagedData<BccPerson> result = await this.httpClient.GetAsync<PagedData<BccPerson>>(url);

            return result.Data?.FirstOrDefault();
        }
        
        public async Task<List<BccOrg>> GetChurchesAsync()
        {
            var url = "org?type=church";

            List<BccOrg> result = await httpClient.GetAsync<List<BccOrg>>(url);

            return result;
        }
    }
}

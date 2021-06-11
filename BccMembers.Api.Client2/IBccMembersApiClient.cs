using System.Threading.Tasks;
using BccMembers.Api.Client.Contracts;

namespace BccMembers.Api.Client
{
    public interface IBccMembersApiClient
    {
        Task<BccPerson> GetPersonAsync(int id);
    }
}

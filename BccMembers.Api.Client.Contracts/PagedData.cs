using System.Collections.Generic;

namespace BccMembers.Api.Client.Contracts
{
    public class PagedData<T> where T : class
    {
        public int Total { get; set; }

        public int Limit { get; set; }

        public int Skip { get; set; }

        public List<T> Data { get; set; } = new List<T>();
    }
}

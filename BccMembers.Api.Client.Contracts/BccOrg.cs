using System;

namespace BccMembers.Api.Client.Contracts
{
    public class BccOrg
    {
        [Obsolete("Use OrgID instead")]
        public int ChurchID => OrgID;
        public int OrgID { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace BccMembers.Api.Client
{
    public class BccMembersApiClientOptions
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
        public string TokenEndpoint { get; set; } = "/oauth/token";

        public string Audience { get; set; } = "bcc.members";

        public string Scope { get; set; } = "members.read_person_id members.read_name";

        public string ApiBasePath { get; set; }

        public string ApiKey { get; set; }
    }
}

using System.Collections.Generic;

namespace BccMembers.Api.Client.Contracts
{
    public class Relationship
    {
        public int PersonID { get; set; }
    }

    public class Relationships
    {
        public List<Relationship> Guardians { get; set; }

        public List<Relationship> Parents { get; set; }

        public List<Relationship> Spouse { get; set; }
    }
}

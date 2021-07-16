using System;

namespace BccMembers.Api.Client.Contracts
{
    public class BccPerson
    {
        public int PersonID { get; set; }

        public string Email { get; set; }

        public MaritalStatus MaritalStatusCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LastNamePrefix { get; set; }

        public string MiddleName { get; set; }

        public string DisplayName { get; set; }

        public int GenderCode { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime? DeceasedDate { get; set; }

        public Address CurrentAddress { get; set; }

        public Phone CellPhone { get; set; }

        public Phone HomePhone { get; set; }

        public DateTime? LastChangedDate { get; set; }

        public int GuardianID { get; set; }

        public int SecondGuardianId { get; set; }

        public int ChurchID { get; set; }

        public Relationships Related { get; set; }
        
        public string CultureCode1 { get; set; }
        public string CultureCode2 { get; set; }
        public string CultureCode3 { get; set; }
    }
}

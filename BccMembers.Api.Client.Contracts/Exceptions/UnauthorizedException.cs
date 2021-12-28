using System;
using System.Collections.Generic;
using System.Text;

namespace BccMembers.Api.Client
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BccMembers.Api.Client
{
    public class ApiRequestException : Exception
    {
        public ApiRequestException(string message) : base(message)
        {
        }
    }
}

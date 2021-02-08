using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.Shared.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {
        }
    }
}

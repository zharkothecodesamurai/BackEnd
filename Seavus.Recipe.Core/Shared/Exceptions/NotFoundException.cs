using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
        public NotFoundException(int Id) : base($"The recourse with id {Id} was not found")
        {
        }
    }
}

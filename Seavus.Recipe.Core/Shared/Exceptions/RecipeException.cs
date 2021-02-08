using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.Shared.Exceptions
{
    public class RecipeException : Exception
    {
        public RecipeException(string message) : base(message)
        {
        }
    }
}

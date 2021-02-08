using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.ViewModels
{
    public class RegisterVievModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}

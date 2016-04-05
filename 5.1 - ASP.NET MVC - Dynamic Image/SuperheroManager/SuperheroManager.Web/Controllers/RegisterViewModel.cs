using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperheroManager.Web.Controllers
{
    public class RegisterViewModel
    {
        public String UserName { get; set; }

        public String Password { get; set; }

        public String PasswordAgain { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecture06.BlogPosts.AspNetMvc.Controllers.ViewModels
{
    public class LoginViewModel
    {
        public String AdditionalMessage { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }
    }
}
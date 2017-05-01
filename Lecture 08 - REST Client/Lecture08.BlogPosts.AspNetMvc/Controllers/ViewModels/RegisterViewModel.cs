using System;

namespace Lecture08.BlogPosts.AspNetMvc.Controllers.ViewModels
{
    public class RegisterViewModel
    {
        public String Username { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public String SecondaryPassword { get; set; }
    }
}
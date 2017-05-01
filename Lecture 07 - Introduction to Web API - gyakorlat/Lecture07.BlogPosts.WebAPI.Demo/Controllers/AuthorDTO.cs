using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lecture07.BlogPosts.WebAPI.Demo.Controllers
{
    [DataContract]
    public class AuthorDTO
    {
        [DataMember]
        public String FullName { get; set; }

        [DataMember]
        public Int32 Id { get; set; }
    }
}
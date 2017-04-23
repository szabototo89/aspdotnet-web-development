using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Lecture07.BlogPosts.WebApi.Models
{
    [DataContract]
    public class AuthorDataTransfer
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public String FullName { get; set; }
    }
}
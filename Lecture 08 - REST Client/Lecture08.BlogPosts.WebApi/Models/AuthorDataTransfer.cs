using System;
using System.Runtime.Serialization;

namespace Lecture08.BlogPosts.WebApi.Models
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
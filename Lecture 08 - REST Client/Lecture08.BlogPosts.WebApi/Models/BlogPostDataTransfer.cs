using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lecture08.BlogPosts.WebApi.Models
{
    [DataContract]
    public class BlogPostDataTransfer
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public String Title { get; set; }

        [DataMember]
        public String Content { get; set; }

        [DataMember]
        public IEnumerable<Int32> Authors { get; set; }
    }
}
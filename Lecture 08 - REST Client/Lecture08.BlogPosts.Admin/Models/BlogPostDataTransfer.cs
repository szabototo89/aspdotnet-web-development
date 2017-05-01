using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lecture08.BlogPosts.Admin.Models
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

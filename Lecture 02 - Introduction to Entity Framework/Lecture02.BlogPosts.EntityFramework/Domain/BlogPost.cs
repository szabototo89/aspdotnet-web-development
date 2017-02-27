using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.SqlServer.Server;

namespace Lecture02.BlogPosts.EntityFramework.Domain
{
    public class BlogPost: IEntity
    {
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public String Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public override String ToString() 
            => $"Id: {Id}, Title: {Title}, Content: {Content}, CreatedDate: {CreatedDate}";
    }
}
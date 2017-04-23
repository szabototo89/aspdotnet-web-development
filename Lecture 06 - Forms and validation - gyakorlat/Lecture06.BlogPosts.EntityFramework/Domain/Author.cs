using System;
using System.Collections.Generic;

namespace Lecture06.BlogPosts.EntityFramework.Domain
{
    public class Author : IEntity
    {
        public Int32 Id { get; set; }

        public String FullName { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }

        public override String ToString() => $"Id: {Id}, FullName: {FullName}";
    }
}
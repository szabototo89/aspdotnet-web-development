﻿using System;
using System.Collections.Generic;

namespace Lecture06.BlogPosts.EntityFramework.Domain
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
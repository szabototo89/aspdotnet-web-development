﻿using System;
using System.Data.Entity;
using Lecture05.BlogPosts.EntityFramework.Domain;

namespace Lecture05.BlogPosts.EntityFramework.Contexts
{
    public class LocalDatabaseContext : DbContext
    {
        public LocalDatabaseContext(String nameOrConnectionString) : base(nameOrConnectionString)
        {
            // var dropCreateDatabaseIfModelChanges = new DropCreateDatabaseIfModelChanges<LocalDatabaseContext>();

            // Jelenleg nem használt:
            var dropCreateDatabaseAlways = new DropCreateDatabaseAlways<LocalDatabaseContext>();

            Database.SetInitializer(dropCreateDatabaseAlways);
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogPost>()
                        .HasKey(blogPost => blogPost.Id);

            modelBuilder.Entity<Author>()
                        .HasKey(author => author.Id)
                        .HasMany(author => author.BlogPosts)
                        .WithMany(blogPost => blogPost.Authors);
        }
    }
}
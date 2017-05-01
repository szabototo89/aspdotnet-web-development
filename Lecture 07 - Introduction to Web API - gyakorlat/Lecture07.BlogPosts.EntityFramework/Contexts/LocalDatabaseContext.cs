using System;
using System.Data.Entity;
using Lecture07.BlogPosts.EntityFramework.Domain;

namespace Lecture07.BlogPosts.EntityFramework.Contexts
{
    public class LocalDatabaseContext : DbContext
    {
        public LocalDatabaseContext(String nameOrConnectionString) : base(nameOrConnectionString)
        {
            var dropCreateDatabaseAlways = new DropCreateDatabaseIfModelChanges<LocalDatabaseContext>();

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
using System;
using System.Linq;
using Lecture04.BlogPosts.EntityFramework.Contexts;
using Lecture04.BlogPosts.EntityFramework.Domain;

namespace Lecture04.BlogPosts.EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Development\Playground\Lecture02.BlogPosts.EntityFramework\Lecture02.BlogPosts.EntityFramework\BlogDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=True";
            using (var context = new LocalDatabaseContext(connectionString))
            {
                AddTestData(context);
                WriteBlogPosts(context);
            }
        }

        private static void AddTestData(LocalDatabaseContext context)
        {
            var blogPost = new BlogPost
            {
                Title = "Test",
                Content = "Lorem ipsum",
                CreatedDate = DateTime.Now,
            };

            var johnDoeAuthor = new Author
            {
                FullName = "John Doe",
                BlogPosts = new[] { blogPost }
            };

            context.Authors.Add(johnDoeAuthor);
            context.BlogPosts.Add(blogPost);

            context.SaveChanges();
        }

        private static void WriteBlogPosts(LocalDatabaseContext context)
        {
            foreach (var blogPost in context.BlogPosts.ToArray())
            {
                Console.WriteLine(blogPost);
                foreach (var author in blogPost.Authors.ToArray())
                {
                    Console.WriteLine(author);
                }
            }

            Console.ReadKey();
        }
    }
}
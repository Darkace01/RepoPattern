using Core;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Test.TestData;

namespace Test
{
    public class TestBase
    {
        protected ApplicationDbContext GetSampleData(string db)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase(databaseName: db);

            var options = builder.Options;

            var context = new ApplicationDbContext(options);

            //Get sample data and save them for testing
           var posts = new List<Post>();
           var users = new List<ApplicationUser>();
           var dataFactory = new DataFactory();

            //user 3
            users.Add(dataFactory.GetApplicationUser("123","user1@email.com","user1","userfullname1","passwordhash"));
            users.Add(dataFactory.GetApplicationUser("1234", "user2@email.com", "user2", "userfullname2", "passwordhash"));
            users.Add(dataFactory.GetApplicationUser("1235", "user3@email.com", "user3", "userfullname3", "passwordhash"));

            context.Users.AddRange(users);
            context.SaveChanges();

            //post 2
            posts.Add(dataFactory.GetPost(1, "post1", "postcontent1", "postdescription1", "posttags", "posturi", dataFactory.GetApplicationUser("1235", "user3@email.com", "user3", "userfullname3", "passwordhash")));
            posts.Add(dataFactory.GetPost(2, "post2", "postcontent2", "postdescription2", "posttags", "posturi", dataFactory.GetApplicationUser("1235", "user3@email.com", "user3", "userfullname3", "passwordhash")));
            context.Post.AddRange(posts);
            context.SaveChanges();

            return context;
        }
    }
}

using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.TestData
{
    public class DataFactory
    {
        public ApplicationUser GetApplicationUser(string id, string email, string username, string fullname, string passwordHash)
        {
            var user = new ApplicationUser
            {
                Id = id,
                Email = email,
                UserName = username,
                FullName = fullname,
                PasswordHash = passwordHash,
            };
            return user;
        }

        public Post GetPost(int id, string title, string content, string description, string tags,string iconUri, ApplicationUser user)
        {
            var post = new Post()
            {
                ID = id,
                Title = title,
                Content = content,
                Description = description,
                DateCreated = DateTime.Today,
                DateModified = DateTime.Today,
                IsDeleted = false,
                Tags = tags,
                IconUri = iconUri,
                ApplicationUser = user

            };
            return post;
        }
    }
}

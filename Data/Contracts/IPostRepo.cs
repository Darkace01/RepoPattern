using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contracts
{
    public interface IPostRepo : ICoreRepo<Post>
    {
        IEnumerable<Post> GetAllPostsWithRelationships();
        Post GetPostWithRelationships(int id);
    }
}

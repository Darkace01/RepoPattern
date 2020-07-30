using Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int Id);
        Task CreatePost(Post post);
        Task UpdatePost(Post post);
        Task DeletePost(Post post);
    }
}

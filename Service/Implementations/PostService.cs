using Core;
using Data.Contracts;
using Data.Implementations;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class PostService : IPostService
    {
        public readonly UnitOfWork _uow;
        public PostService(IUnitOfWork uow)
        {
            this._uow = uow as UnitOfWork;
        }

        public async Task CreatePost(Post post)
        {
            if (post != null)
            {
                _uow.PostRepo.Add(post);
                await _uow.Save();
            }
        }

        public async Task UpdatePost(Post post)
        {
            if (post != null)
            {
                _uow.PostRepo.Update(post);
                await _uow.Save();
            }
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _uow.PostRepo.GetAllPostsWithRelationships().Where(p => !p.IsDeleted);
        }
        public Post GetPostById(int postId)
        {
            return _uow.PostRepo.GetPostWithRelationships(postId);
        }

        public Post GetPostByIdandUserId(int postId, string userId)
        {
            return _uow.PostRepo.GetPostWithRelationshipsByUserId(postId, userId);
        }

        public IEnumerable<Post> GetAllPostByUserId(string Id)
        {
            return _uow.PostRepo.GetAllPostsWithRelationships().Where(p => p.ApplicationUser.Id == Id);
        }

        public Boolean IsTitleExist(string postTitle, string userId)
        {
            var post = _uow.PostRepo.GetAllPostsWithRelationships().Where(p => p.Title == postTitle && p.ApplicationUser.Id == userId).FirstOrDefault();
            if (post != null)
                return true;
            return false;
        }


        public async Task DeletePost(Post post)
        {
            if(post != null)
            {
                _uow.PostRepo.Update(post);
                await _uow.Save();
            }
        }
    }
}

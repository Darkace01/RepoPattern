using Core;
using Data.Contracts;
using Data.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class PostService
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
            return _uow.PostRepo.GetAll().Where(p => !p.IsDeleted);
        }
        public Post GetPostById(int postId)
        {
            return _uow.PostRepo.Find(p => p.ID == postId).Where(p => !p.IsDeleted).FirstOrDefault();
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

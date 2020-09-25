using Core;
using Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Implementations
{
    public class PostRepo : CoreRepo<Post>, IPostRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Post> _DbSet;
        public PostRepo(ApplicationDbContext ctx) : base(ctx)
        {
            this._context = ctx;
            this._DbSet = this._context.Set<Post>();
        }

        public IEnumerable<Post> GetAllPostsWithRelationships()
        {
            return _DbSet
                .Include(p => p.ApplicationUser)
                .ToList();
        }

        public Post GetPostWithRelationships(int id)
        {
            return _DbSet.Where(n => n.ID == id && !n.IsDeleted)
                .Include(p => p.ApplicationUser)
                .FirstOrDefault();
        }
    }

}

using Core;
using Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}

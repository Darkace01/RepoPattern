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
        public PostRepo(ApplicationDbContext ctx) : base(ctx)
        {
        }
    }

}

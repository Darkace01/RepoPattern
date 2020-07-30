using Core;
using Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Implementations
{
    public class UserRepo : CoreRepo<ApplicationUser>, IUserRepo
    {
        public UserRepo(ApplicationDbContext ctx) : base(ctx)
        {

        }
    }
}

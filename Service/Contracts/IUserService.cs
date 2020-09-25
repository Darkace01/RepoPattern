using Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetAllUsers();
        ApplicationUser GetUserById(string Id);
        Task CreateUser(ApplicationUser user);
        Task UpdateUser(ApplicationUser user);
        Task DeleteUser(ApplicationUser user);
    }
}

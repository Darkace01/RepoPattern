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
    public class UserService : IUserService
    {
        public readonly UnitOfWork _uow;
        public UserService(IUnitOfWork uow)
        {
            this._uow = uow as UnitOfWork;
        }
        public async Task CreateUser(ApplicationUser user)
        {
            if (user != null)
            {
                _uow.UserRepo.Add(user);
                await _uow.Save();
            }
        }

        public async Task DeleteUser(ApplicationUser user)
        {
            if (user != null)
            {
                _uow.UserRepo.Add(user);
                await _uow.Save();
            }
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _uow.UserRepo.GetAll();
        }

        public ApplicationUser GetUserById(string Id)
        {
            return _uow.UserRepo.Find(u => u.Id == Id).FirstOrDefault();
        }

        public Task UpdateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}

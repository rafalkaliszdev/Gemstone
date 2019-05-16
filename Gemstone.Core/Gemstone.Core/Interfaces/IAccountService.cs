using Gemstone.Core.DomainModels;
using System.Collections.Generic;

namespace Gemstone.Core.Interfaces
{
    public interface IAccountService
    {
        Account GetById(long id);
        IList<Account> GetAll();
        void Create(Account specialist);
        void Update(Account specialist);
        void Delete(Account specialist);
    }
}

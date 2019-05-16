using Gemstone.Core.DomainModels;
using System.Collections.Generic;

namespace Gemstone.Core.Interfaces
{
    public interface IAssignorService
    {
        Account GetById(long id);
        IList<Account> GetAll();
        void Create(Account specialist);
        void Update(Account specialist);
        void Delete(Account specialist);
    }
}

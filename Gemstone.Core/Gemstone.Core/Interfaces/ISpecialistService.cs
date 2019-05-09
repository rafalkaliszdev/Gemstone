using Gemstone.Core.Domain;
using Gemstone.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gemstone.Core.Interfaces
{
    public interface ISpecialistService
    {
        Account GetById(string id);
        IList<Account> GetAll();
        void Create(Account Specialist);
        void Update(Account Specialist);
        void Delete(Account Specialist);
    }
}

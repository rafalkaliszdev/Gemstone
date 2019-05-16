using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gemstone.Core.Domain;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;

namespace Gemstone.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> repository;

        public AccountService(IRepository<Account> repository)
        {
            this.repository = repository;
        }

        public Account GetById(long id)
        {
            var record = repository.Get(id);
            return record;
        }

        public IList<Account> GetAll()
        {
            var records = repository.GetAll().ToList();
            return records;
        }

        public void Create(Account Account)
        {
            repository.Add(Account);
        }

        public void Update(Account Account)
        {
            var record = repository.Get(Account.Id);
            repository.Update(record, Account);
        }

        public void Delete(Account Account)
        {
            var record = repository.Get(Account.Id);
            repository.Delete(Account);
        }
    }
}

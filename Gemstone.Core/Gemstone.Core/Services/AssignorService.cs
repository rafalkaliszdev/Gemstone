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
    public class AssignorService : IAssignorService
    {
        private readonly IRepository<Account> repository;

        public AssignorService(IRepository<Account> repository)
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

        public void Create(Account Assignor)
        {
            repository.Add(Assignor);
        }

        public void Update(Account Assignor)
        {
            var record = repository.Get(Assignor.Id);
            repository.Update(record, Assignor);
        }

        public void Delete(Account Assignor)
        {
            var record = repository.Get(Assignor.Id);
            repository.Delete(Assignor);
        }
    }
}

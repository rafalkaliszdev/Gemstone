using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var record = repository.GetByIdAsync(id).Result;
            return record;
        }

        public IList<Account> GetAll()
        {
            var records = repository.GetAllAsync().Result;
            return records.ToList();
        }

        public void Create(Account assignor)
        {
            repository.AddAsync(assignor);
        }

        public void Update(Account assignor)
        {
            var record = repository.GetByIdAsync(assignor.ID).Result;
            record = assignor;
            repository.UpdateAsync(record);
        }

        public void Delete(Account assignor)
        {
            var record = repository.GetByIdAsync(assignor.ID);
            repository.DeleteAsync(assignor);
        }
    }
}

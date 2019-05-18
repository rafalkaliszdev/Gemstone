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
        private readonly IRepository<Account> accountRepository;

        public AssignorService(IRepository<Account> repository)
        {
            this.accountRepository = repository;
        }

        public Account GetAssignorById(long id)
        {
            var record = accountRepository.ReadByIdAsync(id).Result;
            return record;
        }

        public IList<Account> GetAllAssignors()
        {
            // todo test it
            var query = from acc in accountRepository.ReadAllAsync()
                        where acc.AccountRole == AccountRole.Assignor
                        select acc;

            return query.ToList();
        }

        public void CreateAssignor(Account assignor)
        {
            accountRepository.CreateAsync(assignor);
        }

        public void UpdateAssignor(Account assignor)
        {
            var record = accountRepository.ReadByIdAsync(assignor.ID).Result;
            record = assignor;
            accountRepository.UpdateAsync(record);
        }

        public void DeleteAssignor(Account assignor)
        {
            var record = accountRepository.ReadByIdAsync(assignor.ID);
            accountRepository.DeleteAsync(assignor);
        }
    }
}

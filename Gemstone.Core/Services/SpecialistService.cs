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
    public class SpecialistService : ISpecialistService
    {
        private readonly IRepository<Account> accountRepository;

        public SpecialistService(IRepository<Account> repository)
        {
            this.accountRepository = repository;
        }

        public Account GetSpecialistById(long id)
        {
            var record = accountRepository.ReadByIdAsync(id).Result;
            return record;
        }

        public async Task<IReadOnlyCollection<Account>> GetAllSpecialists()
        {
            // todo test it
            var records = await accountRepository.ReadAllAsync();
            return records;
        }

        public void CreateSpecialist(Account specialist)
        {
            accountRepository.CreateAsync(specialist);
        }

        public void UpdateSpecialist(Account specialist)
        {
            var record = accountRepository.ReadByIdAsync(specialist.ID).Result;
            record = specialist;
            accountRepository.UpdateAsync(record);
        }

        public void DeleteSpecialist(Account specialist)
        {
            var record = accountRepository.ReadByIdAsync(specialist.ID);
            accountRepository.DeleteAsync(specialist);
        }
    }
}

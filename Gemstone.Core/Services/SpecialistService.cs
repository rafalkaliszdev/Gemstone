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
        private readonly IRepository<Account> repository;

        public SpecialistService(IRepository<Account> repository)
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

        public void Create(Account specialist)
        {
            repository.AddAsync(specialist);
        }

        public void Update(Account specialist)
        {
            var record = repository.GetByIdAsync(specialist.ID).Result;
            record = specialist;
            repository.UpdateAsync(record);
        }

        public void Delete(Account specialist)
        {
            var record = repository.GetByIdAsync(specialist.ID);
            repository.DeleteAsync(specialist);
        }
    }
}

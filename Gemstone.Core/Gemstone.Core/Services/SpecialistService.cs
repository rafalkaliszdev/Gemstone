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
    public class SpecialistService : ISpecialistService
    {
        private readonly IRepository<Account> repository;

        public SpecialistService(IRepository<Account> repository)
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

        public void Create(Account specialist)
        {
            repository.Add(specialist);
        }

        public void Update(Account specialist)
        {
            var record = repository.Get(specialist.Id);
            repository.Update(record, specialist);
        }

        public void Delete(Account specialist)
        {
            var record = repository.Get(specialist.Id);
            repository.Delete(specialist);
        }
    }
}

using Gemstone.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Gemstone.Core.DomainModels;
using Gemstone.Infrastructure.DataInitialization;
using Gemstone.Core.Interfaces;

namespace Gemstone.Infrastructure
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly GemstoneDbContext _context;

        public AccountRepository(GemstoneDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Account.ToList();
        }

        public Account Get(long id)
        {
            return _context.Account
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Account entity)
        {
            _context.Account.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Account model, Account entity)
        {
            model.Name = entity.Name;
            model.IsBusy = entity.IsBusy;
            model.JoinedOn = entity.JoinedOn;

            _context.SaveChanges();
        }

        public void Delete(Account model)
        {
            _context.Account.Remove(model);
            _context.SaveChanges();
        }
    }
}
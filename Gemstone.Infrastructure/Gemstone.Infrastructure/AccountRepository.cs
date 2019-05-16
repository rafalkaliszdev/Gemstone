using Gemstone.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Gemstone.Core.DomainModels;
using Gemstone.Infrastructure.DataInitialization;
using Gemstone.Core.Interfaces;
using System.Threading.Tasks;

namespace Gemstone.Infrastructure
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly GemstoneDbContext _context;

        public AccountRepository(GemstoneDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _context.Account.ToListAsync();
        }

        public async Task<Account> Get(long id)
        {
            return await _context.Account
                  .FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task Add(Account entity)
        {
            await _context.Account.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Account model, Account entity)
        {
            model.Username = entity.Username;
            model.AccountRole = entity.AccountRole;
            model.Password = entity.Password;
            model.JoinedOn = entity.JoinedOn;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Account model)
        {
            _context.Account.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
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

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Account.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(long id)
        {
            return await _context.Account
                  .FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task AddAsync(Account entity)
        {
            await _context.Account.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account entity)
        {
            // todo ensure it works correctly
            _context.Account.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Account model)
        {
            _context.Account.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
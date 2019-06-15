using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using Gemstone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Infrastructure
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly EfDbContext _context;

        public AccountRepository(EfDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Account>> ReadAllAsync()
        {
            var records = await (from acc in _context.Account
                                 select acc).AsNoTracking().ToListAsync();
            return records.AsReadOnly();
        }

        public async Task<Account> ReadByIdAsync(long id)
        {
            var record = await (from acc in _context.Account
                                where acc.ID == id
                                select acc ).SingleOrDefaultAsync();
            return record;
        }

        public async Task CreateAsync(Account entity)
        {
            await _context.Account.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account entity)
        {
            _context.Account.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Account model)
        {
            _context.Account.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(long id)
        {
            return await _context.Account.AnyAsync(p => p.ID == id);
        }
    }
}
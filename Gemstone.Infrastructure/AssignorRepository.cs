using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;
using Gemstone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Infrastructure
{
    public class AssignorRepository : IRepository<Assignor>
    {
        private readonly EfDbContext _context;

        public AssignorRepository(EfDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Assignor>> ReadAllAsync()
        {
            var records = await (from acc in _context.Account
                                 where acc.AccountRole == AccountRole.Assignor
                                 select acc as Assignor).AsNoTracking().ToListAsync();
            return records.AsReadOnly();
        }

        public async Task<Assignor> ReadByIdAsync(long id)
        {
            var record = await (from acc in _context.Account
                                where acc.AccountRole == AccountRole.Assignor
                                where acc.ID == id
                                select acc as Assignor).SingleOrDefaultAsync();
            return record;
        }

        public Task CreateAsync(Assignor entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Assignor entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Assignor model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsById(long id)
        {
            return await _context.Account.AnyAsync(p => p.ID == id);
        }
    }
}
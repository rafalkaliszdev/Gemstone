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
using Gemstone.Core.Enums;

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

        public async Task CreateAsync(Assignor entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Assignor entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Assignor model)
        {
            throw new NotImplementedException();
        }
    }
}
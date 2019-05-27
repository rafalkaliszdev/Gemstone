using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;
using Gemstone.Infrastructure.DataInitialization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Infrastructure
{
    public class SpecialistRepository : IRepository<Specialist>
    {
        private readonly EfDbContext _context;

        public SpecialistRepository(EfDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Specialist>> ReadAllAsync()
        {
            var records = await (from acc in _context.Account
                                 where acc.AccountRole == AccountRole.Specialist
                                 select acc as Specialist).AsNoTracking().ToListAsync();
            return records.AsReadOnly();
        }

        public async Task<Specialist> ReadByIdAsync(long id)
        {
            // todo right way to handle exceptions in Repositories
            // issue somehow i can't cast it the same way as in ReadAllAync()
            var account = await (from acc in _context.Account
                                 where acc.ID == id
                                 select acc).SingleOrDefaultAsync();
            return account.AccountRole == AccountRole.Specialist ? account as Specialist : null;
        }

        public Task CreateAsync(Specialist entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Specialist entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Specialist model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
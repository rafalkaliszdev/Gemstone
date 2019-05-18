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
            var record = await (from acc in _context.Account
                                where acc.AccountRole == AccountRole.Specialist
                                where acc.ID == id
                                select acc as Specialist).SingleOrDefaultAsync();
            return record;
        }

        public async Task CreateAsync(Specialist entity)
        {
            await _context.Account.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Specialist entity)
        {
            // todo ensure it works correctly
            _context.Account.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Specialist model)
        {
            _context.Account.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
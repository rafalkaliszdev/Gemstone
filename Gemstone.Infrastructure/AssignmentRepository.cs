using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using Gemstone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Infrastructure
{
    public class AssignmentRepository : IRepository<Assignment>
    {
        private readonly EfDbContext _context;

        public AssignmentRepository(EfDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Assignment entity)
        {
            await _context.Assignment.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Assignment entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsById(long id)
        {
            return await _context.Assignment.AnyAsync(p => p.ID == id);
        }

        public Task<IReadOnlyCollection<Assignment>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Assignment> ReadByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Assignment entity)
        {
            throw new NotImplementedException();
        }
    }
}
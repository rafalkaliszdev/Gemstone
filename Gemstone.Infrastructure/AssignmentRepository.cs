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
    public class AssignmentRepository : IRepository<Assignment>
    {
        private readonly EfDbContext _context;

        public AssignmentRepository(EfDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(Assignment model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Assignment model)
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
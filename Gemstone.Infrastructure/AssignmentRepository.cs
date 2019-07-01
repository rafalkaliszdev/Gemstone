using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using Gemstone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gemstone.Core.Interfaces.Repositories;

namespace Gemstone.Infrastructure
{
    public class AssignmentRepository : EfRepository<Assignment>, IAssignmentRepository
    {
        //private readonly EfDbContext _context;

        public AssignmentRepository(EfDbContext dbContext) : base(dbContext)
        {
            //_context = context;
        }

        //public async Task AddAsync(Assignment entity)
        //{
        //    await _context.Assignment.AddAsync(entity);
        //    await _context.SaveChangesAsync();
        //}

        //public Task DeleteAsync(Assignment entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<bool> ExistsById(long id)
        //{
        //    return await _context.Assignment.AnyAsync(p => p.ID == id);
        //}


    }
}
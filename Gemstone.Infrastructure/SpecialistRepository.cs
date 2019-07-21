using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;
using Gemstone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Gemstone.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Gemstone.Infrastructure
{
    public class SpecialistRepository : EfRepository<Specialist>, ISpecialistRepository
    {

        public SpecialistRepository(EfDbContext context) : base(context) { }

        //public async Task<IReadOnlyCollection<Specialist>> ListAllAsync()
        //{
        //    var records = await (from acc in _context.Account
        //                         where acc.AccountRole == AccountRole.Specialist
        //                         select acc as Specialist).AsNoTracking().ToListAsync();
        //    return records.AsReadOnly();
        //}

        //public async Task<Specialist> GetByIdAsync(long id)
        //{
        //    var specialist = await _context.Account
        //        .Cast<Specialist>()
        //        .Where(acc => acc.ID == id)
        //        .Include(spec => spec.Assignments)
        //        .ThenInclude(assignment => assignment.Assignor)
        //        .SingleOrDefaultAsync();

        //    return specialist;
        //}




    }
}
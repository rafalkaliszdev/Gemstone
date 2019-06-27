using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;
using Gemstone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gemstone.Core.Interfaces.Repositories;

namespace Gemstone.Infrastructure
{
    public class AssignorRepository : EfRepository<Assignor>, IAssignorRepository
    {

        public AssignorRepository(EfDbContext context) : base(context)
        {
        }

        //public async Task<IReadOnlyCollection<Assignor>> ListAllAsync()
        //{
        //    var records = await (from acc in _context.Account
        //                         where acc.AccountRole == AccountRole.Assignor
        //                         select acc as Assignor).AsNoTracking().ToListAsync();
        //    return records.AsReadOnly();
        //}

        //public async Task<Assignor> GetByIdAsync(long id)
        //{
        //    var record = await (from acc in _context.Account
        //                        where acc.AccountRole == AccountRole.Assignor
        //                        where acc.ID == id
        //                        select acc as Assignor).SingleOrDefaultAsync();
        //    return record;
        //}
    }
}
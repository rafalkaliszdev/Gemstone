﻿using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using Gemstone.Core.Interfaces.Repositories;
using Gemstone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Infrastructure
{
    public class AccountRepository : EfRepository<Account>, IAccountRepository
    {
        private readonly EfDbContext _context;

        public AccountRepository(EfDbContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<IReadOnlyCollection<Account>> ListAllAsync()
        //{
        //    var records = await (from acc in _context.Account
        //                         select acc).AsNoTracking().ToListAsync();
        //    return records.AsReadOnly();
        //}

        //public async Task<Account> GetByIdAsync(long id)
        //{
        //    var record = await (from acc in _context.Account
        //                        where acc.ID == id
        //                        select acc ).SingleOrDefaultAsync();
        //    return record;
        //}




    }
}
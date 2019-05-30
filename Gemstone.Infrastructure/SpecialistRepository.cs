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

            var specs = _context.Account.Cast<Specialist>();

            var spec = specs
                 .Where(acc => acc.ID == id)
                 //.Include(x => x.Assignments)
                 .SingleOrDefault();

            return spec;

            // todo right way to handle exceptions in Repositories
            // issue somehow i can't cast it the same way as in ReadAllAync()
            var accounts = (from acc in _context.Account
                            where acc.ID == id
                            select acc);// as IQueryable<Specialist>;


            var account = accounts
                .Where(acc => acc.ID == id)
                .Select(fffff).SingleOrDefault();

            return account;// account.AccountRole == AccountRole.Specialist ? account as Specialist : null;
        }

        public Specialist fffff(Account acc)
        {
            return new Specialist
            {
                AccountRole = acc.AccountRole,
                Assignments = (acc as Specialist).Assignments,
                CraftAreaName = (acc as Specialist).CraftAreaName,
                IsBusy = (acc as Specialist).IsBusy,
                ID = acc.ID,
            };
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
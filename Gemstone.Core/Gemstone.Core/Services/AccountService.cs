using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemstone.Core.Domain;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;

namespace Gemstone.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> accountRepository;

        public AccountService(IRepository<Account> accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task AddNewAccount(Account account)
        {
            await accountRepository.Add(account);
        }

        // todo make it async
        public Account AuthenciateAccount(string username, string password)
        {
            var accounts = accountRepository.GetAll();
            var account = accounts
                .SingleOrDefault(
                acc => acc.Username.ToLowerInvariant() == username.ToLowerInvariant() &&
                acc.Password.ToLowerInvariant() == password.ToLowerInvariant());
            return account;
        }
    }
}
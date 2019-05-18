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

        public void AddNewAccount(Account account)
        {
            accountRepository.CreateAsync(account);
        }

        public async Task<Account> AuthenciateAccount(string username, string password)
        {
            var accounts = await accountRepository.ReadAllAsync();
            var account = accounts
                .SingleOrDefault(
                acc => acc.Username.ToLowerInvariant() == username.ToLowerInvariant() &&
                acc.Password.ToLowerInvariant() == password.ToLowerInvariant());
            return account;
        }

        public async Task<bool> UsernameIsUnique(string username)
        {
            var accounts = await accountRepository.ReadAllAsync();
            var account = accounts.SingleOrDefault(acc => acc.Username.ToLowerInvariant() == username.ToLowerInvariant());
            return account == null;
        }
    }
}
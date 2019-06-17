using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAsyncRepository<Account> accountRepository;

        public AccountService(IAsyncRepository<Account> accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void AddNewAccount(Account account)
        {
            accountRepository.AddAsync(account);
        }

        public async Task<Account> AuthenciateAccount(string username, string password)
        {
            var accounts = await accountRepository.ListAllAsync();
            var account = accounts
                .SingleOrDefault(
                acc => acc.Username.ToLowerInvariant() == username.ToLowerInvariant() &&
                acc.Password.ToLowerInvariant() == password.ToLowerInvariant());
            return account;
        }

        public async Task<bool> UsernameIsUnique(string username)
        {
            var accounts = await accountRepository.ListAllAsync();
            var account = accounts.SingleOrDefault(acc => acc.Username.ToLowerInvariant() == username.ToLowerInvariant());
            return account == null;
        }
    }
}
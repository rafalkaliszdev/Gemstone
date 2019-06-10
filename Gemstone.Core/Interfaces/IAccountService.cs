using Gemstone.Core.DomainModels;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Registers new Account
        /// </summary>
        void AddNewAccount(Account account);
        /// <summary>
        /// Returns Account record if exist, null if not
        /// </summary>
        Task<Account> AuthenciateAccount(string username, string password);
        /// <summary>
        /// Returns true if given string is unique in database
        /// </summary>
        Task<bool> UsernameIsUnique(string username);
    }
}
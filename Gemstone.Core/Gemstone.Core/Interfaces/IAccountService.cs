using Gemstone.Core.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Registers new Account
        /// </summary>
        Task AddNewAccount(Account account);
        /// <summary>
        /// Returns Account record if exist, null if not
        /// </summary>
        Account AuthenciateAccount(string username, string password);
    }
}
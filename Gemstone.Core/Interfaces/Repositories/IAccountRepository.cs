﻿using Gemstone.Core.DomainModels;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces.Repositories
{
    public interface IAccountRepository : IAsyncRepository<Account>
    {
    }
}
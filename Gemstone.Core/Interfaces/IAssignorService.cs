using Gemstone.Core.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces
{
    public interface IAssignorService
    {
        Task<bool> AssignorExistsById(long id);
        Task<Assignor> GetAssignorById(long id);
    }
}
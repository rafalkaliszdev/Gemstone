using Gemstone.Core.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces
{
    public interface ISpecialistService
    {
        Account GetSpecialistById(long id);
        Task<IReadOnlyCollection<Account>> GetAllSpecialists();
        void CreateSpecialist(Account specialist);
        void UpdateSpecialist(Account specialist);
        void DeleteSpecialist(Account specialist);
    }
}
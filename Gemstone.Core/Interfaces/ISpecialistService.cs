using Gemstone.Core.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces
{
    public interface ISpecialistService
    {
        Task<Specialist> GetSpecialistById(long id);
        Task<IReadOnlyCollection<Specialist>> GetAllSpecialists();
        void CreateSpecialist(Specialist specialist);
        void UpdateSpecialist(Specialist specialist);
        void DeleteSpecialist(Specialist specialist);
    }
}
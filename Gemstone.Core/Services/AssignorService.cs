using Gemstone.Core.Interfaces.Repositories;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using System.Threading.Tasks;

namespace Gemstone.Core.Services
{
    public class AssignorService : IAssignorService
    {
        private readonly IAsyncRepository<Assignor> assignorRepository;

        public AssignorService(IAsyncRepository<Assignor> repository)
        {
            this.assignorRepository = repository;
        }

        public async Task<bool> AssignorExistsById(long id)
        {
            return await assignorRepository.ExistsById(id);
        }

        public async Task<Assignor> GetAssignorById(long id)
        {
            var record = await assignorRepository.GetByIdAsync(id);
            return record;
        }
    }
}

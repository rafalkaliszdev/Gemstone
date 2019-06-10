using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using System.Threading.Tasks;

namespace Gemstone.Core.Services
{
    public class AssignorService : IAssignorService
    {
        private readonly IRepository<Assignor> assignorRepository;

        public AssignorService(IRepository<Assignor> repository)
        {
            this.assignorRepository = repository;
        }

        public async Task<bool> AssignorExistsById(long id)
        {
            var record = await assignorRepository.ReadByIdAsync(id);
            return record != null;
        }

        public async Task<Assignor> GetAssignorById(long id)
        {
            var record = await assignorRepository.ReadByIdAsync(id);
            return record;
        }
    }
}

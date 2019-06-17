using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Core.Services
{
    public class SpecialistService : ISpecialistService
    {
        private readonly IAsyncRepository<Specialist> specialistRepository;

        public SpecialistService(IAsyncRepository<Specialist> repository)
        {
            this.specialistRepository = repository;
        }

        public async Task<bool> SpecialistExistsById(long id)
        {
            return await specialistRepository.ExistsById(id);
        }

        public async Task<Specialist> GetSpecialistById(long id)
        {
            var record = await specialistRepository.GetByIdAsync(id);
            return record;
        }

        public async Task<IReadOnlyCollection<Specialist>> GetAllSpecialists()
        {
            var records = await specialistRepository.ListAllAsync();
            return records;
        }
    }
}
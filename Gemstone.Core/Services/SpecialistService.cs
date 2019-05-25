using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemstone.Core.Domain;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;

namespace Gemstone.Core.Services
{
    public class SpecialistService : ISpecialistService
    {
        private readonly IRepository<Specialist> specialistRepository;

        public SpecialistService(IRepository<Specialist> repository)
        {
            this.specialistRepository = repository;
        }

        public async Task<Specialist> GetSpecialistById(long id)
        {
            var record = await specialistRepository.ReadByIdAsync(id);
            return record;
        }

        public async Task<IReadOnlyCollection<Specialist>> GetAllSpecialists()
        {
            var records = await specialistRepository.ReadAllAsync();
            return records;
        }

        public void CreateSpecialist(Specialist specialist)
        {
            specialistRepository.CreateAsync(specialist);
        }

        public void UpdateSpecialist(Specialist specialist)
        {
            var record = specialistRepository.ReadByIdAsync(specialist.ID).Result;
            record = specialist;
            specialistRepository.UpdateAsync(record);
        }

        public void DeleteSpecialist(Specialist specialist)
        {
            var record = specialistRepository.ReadByIdAsync(specialist.ID);
            specialistRepository.DeleteAsync(specialist);
        }
    }
}

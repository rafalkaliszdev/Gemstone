using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Gemstone.Core.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository<Assignment> assignmentRepository;
        private readonly ISpecialistService specialistService;
        private readonly IAssignorService assignorService;

        public AssignmentService(IRepository<Assignment> repository, ISpecialistService specialistService, IAssignorService assignorService)
        {
            this.assignmentRepository = repository;
            this.specialistService = specialistService;
            this.assignorService = assignorService;
        }

        public async Task<bool> AssignmentExistsById(long id)
        {
            var record = await assignmentRepository.ReadByIdAsync(id);
            return record != null;
        }

        public async Task<Assignment> GetAssignmentById(long id)
        {
            var record = await assignmentRepository.ReadByIdAsync(id);
            return record;
        }
        public async Task CreateAssignment(Assignment assignment)
        {
            if (await specialistService.SpecialistExistsById(assignment.SpecialistID))
                throw new InvalidOperationException();
            if (await assignorService.AssignorExistsById(assignment.AssignorID))
                throw new InvalidOperationException();

            await assignmentRepository.CreateAsync(assignment);
        }
    }
}

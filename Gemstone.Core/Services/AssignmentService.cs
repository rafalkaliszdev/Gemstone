using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;

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
            if (await specialistService.SpecialistExistsById(assignment.notSpecialistID))
                throw new InvalidOperationException();
            if (await assignorService.AssignorExistsById(assignment.notAssignorID))
                throw new InvalidOperationException();

            await assignmentRepository.CreateAsync(assignment);
        }
    }
}

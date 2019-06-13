using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Gemstone.Core.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository<Assignment> assignmentRepository;
        private readonly ISpecialistService specialistService;
        private readonly IAssignorService assignorService;
        private readonly IHttpContextAccessor httpContext;

        public AssignmentService(IRepository<Assignment> repository, ISpecialistService specialistService, IAssignorService assignorService)
        {
            this.assignmentRepository = repository;
            this.specialistService = specialistService;
            this.assignorService = assignorService;
        }

        public async Task<bool> AssignmentExistsById(long id)
        {
            return await assignmentRepository.ExistsById(id);
        }

        public async Task<Assignment> GetAssignmentById(long id)
        {
            var record = await assignmentRepository.ReadByIdAsync(id);
            return record;
        }
        public async Task CreateAssignment(Assignment assignment)
        {
            // todo find better way to retrieve current user data
            var assignorId = httpContext.HttpContext.User.Identities
                .FirstOrDefault()
                .Claims
                .SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            var assignorIdParsed = int.Parse(assignorId);
            assignment.AssignorID = assignorIdParsed;

            if (!await specialistService.SpecialistExistsById(assignment.SpecialistID))
                throw new InvalidOperationException();

            await assignmentRepository.CreateAsync(assignment);
        }
    }
}

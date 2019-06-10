using Gemstone.Core.DomainModels;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces
{
    public interface IAssignmentService
    {
        Task<bool> AssignmentExistsById(long id);
        Task<Assignment> GetAssignmentById(long id);
        Task CreateAssignment(Assignment assignment);
    }
}
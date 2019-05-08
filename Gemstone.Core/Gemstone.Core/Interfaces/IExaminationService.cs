using Gemstone.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;

namespace Gemstone.Core.Interfaces
{
    public interface IExaminationService
    {
        void ExamineRoles(ClaimsPrincipal claimsPrincipal);
        void ExamineMiddleware(IDictionary<object,object> items);
    }
}

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Gemstone.Core.Domain;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;

namespace Gemstone.Core.Services
{
    public class ExaminationService : IExaminationService
    {
        public void ExamineRoles(ClaimsPrincipal claimsPrincipal)
        {
            if (null != claimsPrincipal)
            {
                foreach (System.Security.Claims.Claim claim in claimsPrincipal.Claims)
                {
                }
            }

            var isAssignor = claimsPrincipal.IsInRole("Assignor");
        }
    }
}

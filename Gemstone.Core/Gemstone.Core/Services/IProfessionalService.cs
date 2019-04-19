using Gemstone.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gemstone.Core.Services
{
    public interface IProfessionalService
    {
        IList<Professional> GetAllProfessionals();
    }
}

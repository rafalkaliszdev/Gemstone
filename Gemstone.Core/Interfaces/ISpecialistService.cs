﻿using Gemstone.Core.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces
{
    public interface ISpecialistService
    {
        Task<bool> SpecialistExistsById(long id);
        Task<Specialist> GetSpecialistById(long id);
        Task<IReadOnlyCollection<Specialist>> GetAllSpecialists();
    }
}
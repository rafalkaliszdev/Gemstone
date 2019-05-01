using Gemstone.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gemstone.Core.Services
{
    public interface ISpecialistService
    {
        Specialist GetById(string id);
        IList<Specialist> GetAll();
        void Create(Specialist Specialist);
        void Update(Specialist Specialist);
        void Delete(Specialist Specialist);
    }
}

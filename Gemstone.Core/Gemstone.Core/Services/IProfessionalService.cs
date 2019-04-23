using Gemstone.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gemstone.Core.Services
{
    public interface IProfessionalService
    {
        Professional GetById(string id);
        IList<Professional> GetAll();
        void Create(Professional professional);
        void Update(Professional professional);
        void Delete(Professional professional);
    }
}

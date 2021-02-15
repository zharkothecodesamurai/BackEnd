using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seavus.Recipe.Core.DataAccess
{
    public interface IIngridientRepository
    {
        Task<Ingridient> GetIngridientById(Guid Id);
        Task Update(Ingridient ingridient);
    }
}

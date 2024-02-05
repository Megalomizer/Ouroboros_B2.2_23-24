using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.Abstractions
{
    public interface IBaseRepository<T> : IDisposable where T : TableData, new()
    {
        // Create/Update
        void SaveEntity(T entity, bool recursive = false);

        // Read One Entity
        T? GetEntity(int id);

        // Read All Entities
        List<T> GetEntities();

        // Delete Entity
        void DeleteEntity(T entity);
    }
}

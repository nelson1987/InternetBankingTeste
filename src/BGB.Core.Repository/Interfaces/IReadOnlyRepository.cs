using System.Collections.Generic;

namespace BGB.Core.Repository.Interfaces
{
    public interface IReadOnlyRepository<TEntity>
    {
        IEnumerable<TEntity> LoadAll();
        TEntity LoadById(int id, bool @readonly = true);
        TEntity LoadById(long id, bool @readonly = true);
        TEntity LoadById(string id, bool @readonly = true);
    }
}
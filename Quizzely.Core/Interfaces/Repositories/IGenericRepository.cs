using Quizzely.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(TKey id);

        Task AddAsync(TEntity entity);

        void Update (TEntity entity); 

        void Delete (TEntity entity);
    }
}

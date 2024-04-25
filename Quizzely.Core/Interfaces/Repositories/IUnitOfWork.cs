using Quizzely.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<int> CompleteAsync();

        IGenericRepository<TEntity,TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}

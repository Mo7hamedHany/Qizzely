using Quizzely.Core.Interfaces.Repositories;
using Quizzely.Core.Models;
using Quizzely.Repository.Data.Contexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SqlDataContext _context;
        private readonly Hashtable _repositories;

        public UnitOfWork(SqlDataContext context)
        {
            _context = context;
            _repositories = new();
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var typeName = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(typeName))
            {
                var repo = new GenericRepository<TEntity, TKey>(_context);

                _repositories.Add(typeName, repo);

                return repo;
            }

            return (_repositories[typeName] as GenericRepository<TEntity, TKey>)!;
        }
    }
}

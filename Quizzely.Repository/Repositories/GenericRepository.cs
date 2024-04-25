using Microsoft.EntityFrameworkCore;
using Quizzely.Core.Interfaces.Repositories;
using Quizzely.Core.Models;
using Quizzely.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Repository.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly SqlDataContext _context;

        public GenericRepository(SqlDataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

        public  void Delete(TEntity entity) =>  _context.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

           //         if (typeof(TEntity) == typeof(McqQuestion))
           //     return (IReadOnlyList<TEntity>) await _context.Set<McqQuestion>().Include(s => s.Exam.Name).ToListAsync();
            
           //return await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(TKey id) => (await _context.Set<TEntity>().FindAsync(id))!;

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
    }
}

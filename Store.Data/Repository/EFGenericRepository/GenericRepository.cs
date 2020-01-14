using Microsoft.EntityFrameworkCore;
using Store.Data.ApplicationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Data.Repository.EFGenericRepository
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity: class
    {
        protected ApplicationDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            _dbSet.Add(item);
            SaveChanges();
        }

        public TEntity Get(Guid id)
        {
            return _dbSet.Find(id);
        }

        public ICollection<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

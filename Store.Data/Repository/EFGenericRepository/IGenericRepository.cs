using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.Repository.EFGenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        public void Remove(TEntity item);
        public void Add(TEntity item);
        public void Update(TEntity item);
        public TEntity Get(Guid id);
        ICollection<TEntity> Get(Func<TEntity, bool> predicate);
        public IEnumerable<TEntity> GetAll();
        public void SaveChanges();
    }
}

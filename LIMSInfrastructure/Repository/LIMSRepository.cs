using LIMSInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LIMSInfrastructure.Repository
{
    public class LIMSRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly LIMSCoreDbContext _context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public LIMSRepository(LIMSCoreDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            SaveChange();
        }

        public T Get(long id)
        {
            return entities.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return entities.AsQueryable();
        }

        public IQueryable<T> GetQueryable(long id)
        {
            return entities.Where(x => x.Id == id).AsQueryable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            SaveChange();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            SaveChange();
        }

        private void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}

using LIMSCore.Entities;
using System.Linq;

namespace LIMSInfrastructure.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(long id);
        IQueryable<T> GetQueryable(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

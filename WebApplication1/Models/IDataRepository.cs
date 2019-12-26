using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IQueryable<Employee> GetAll(int skipcount, int takeount);
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
        int RecordCountEmployee();
    }
}

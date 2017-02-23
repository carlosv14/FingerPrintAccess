using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Service.Interfaces
{
    public interface ICrudService <TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TEntity Create(TEntity entity);
        TEntity Update(long id, TEntity entity);
        TEntity Remove(long id);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

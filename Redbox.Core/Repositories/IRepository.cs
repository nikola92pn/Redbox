using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redbox.Core.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Create(T model);
        Task<bool> Delete(params object[] keyValues);
        Task<T> Update(T model);
        Task<T> GetById(params object[] keyValues);
        Task<IEnumerable<T>> GetAll();
    }
}

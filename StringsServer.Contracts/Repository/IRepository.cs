using System.Collections.Generic;
using System.Threading.Tasks;

namespace StringsServer.Contracts.Repository
{
    public interface IRepository<T>
        where T : IHasId
    {
        Task InsertAsync(T item);

        Task<IEnumerable<T>> ReadAllAsync();
    }
}
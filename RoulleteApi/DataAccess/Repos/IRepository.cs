using System.Collections.Generic;

namespace RoulleteApi.DataAccess
{
    public interface IRepository<T>
    {
        T Add(T value);
        T Update(T value);
        T Get(string id);
        IEnumerable<T> GetAll();
        void Delete(string id);
    }
}

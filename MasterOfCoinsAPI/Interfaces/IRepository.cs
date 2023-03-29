using System.Collections.Generic;

namespace MasterOfCoinsAPI.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        bool Delete(int id);        
    }
}

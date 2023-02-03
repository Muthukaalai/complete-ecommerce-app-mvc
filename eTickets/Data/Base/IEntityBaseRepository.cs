using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()  
        // This interface is to be generic so passing T as parameter and defining T above
        // base repository to inherit from here so we are adding parameters also inherit from IentityBase
    {
        // copied below methods from IActorsServices.cs to use for other methods
        Task<IEnumerable<T>> GetAllAsync(); 
        Task<T> GetByIdAsync(int id);  
        Task AddAsync(T entity); 
        Task UpdateAsync(int id, T entity);  
        Task DeleteAsync(int id);
    }
}

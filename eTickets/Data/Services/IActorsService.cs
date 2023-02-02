using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<ActorM>> GetAllAsync(); // to get all actors from db - IEnumerable<actor> is returntype
        Task<ActorM> GetByIdAsync(int id);  // to get single actor from db
        Task AddAsync(ActorM actor); // to add an actor and we are not returning to user so used Void
        Task<ActorM> UpdateAsync(int id, ActorM newActor);  // check id is exist before update
        Task DeleteAsync(int id);

    }
}

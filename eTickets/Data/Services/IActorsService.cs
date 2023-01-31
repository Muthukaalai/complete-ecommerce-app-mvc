using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<ActorM>> GetAll(); // to get all actors from db - IEnumerable<actor> is returntype
        ActorM GetById(int id);  // to get single actor from db
        void Add(ActorM actor); // to add an actor and we are not returning to user so used Void
        ActorM Update(int id, ActorM newActor);  // check id is exist before update
        void Delete(int id);

    }
}

using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;  // inject IActorsService in ActionsController.cs instead of AppDbContext there
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(ActorM actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ActorM>> GetAll()
        {
            var result = await  _context.Actors.ToListAsync();
            return result;
        }

        public ActorM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ActorM Update(int id, ActorM newActor)
        {
            throw new NotImplementedException();
        }
    }
}

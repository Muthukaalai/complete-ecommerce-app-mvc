using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<ActorM>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }
       
        //public async Task AddAsync(ActorM actor)
        //{
        //    await _context.Actors.AddAsync(actor);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
        //    _context.Actors.Remove(result);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<ActorM>> GetAllAsync()
        //{
        //    var result = await _context.Actors.ToListAsync();
        //    return result;
        //}

        //public async Task<ActorM> GetByIdAsync(int id)
        //{
        //    var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
        //    return result;
        //}

        //public async Task<ActorM> UpdateAsync(int id, ActorM newActor)
        //{
        //    _context.Update(newActor);
        //    await _context.SaveChangesAsync();
        //    return newActor;
        //}
    }
}

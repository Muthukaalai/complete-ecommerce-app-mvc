﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;  // inject AppDbContext to access data from database

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
       
        public async Task<IEnumerable<T>> GetAllAsync() =>  await _context.Set<T>().ToListAsync();
        // removed same this method fron ActorsService.cs to implement commonly
        // here T act as class refer above

        //----------ALTERNATE METHOD BELOW-------------//
        //public async Task<IEnumerable<T>> GetAllAsync()  // removed same this method fron ActorsService.cs to implement commonly
        //{
        //    var result = await _context.Set<T>().ToListAsync();  // here T act as class refer above
        //    return result;
        //}

        public async Task<T> GetByIdAsync(int id)  => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

    }
}
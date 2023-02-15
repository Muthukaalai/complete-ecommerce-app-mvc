using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>    // DbContext - commenting this to use IdentityDbContext for Auth & Authen
    {
        // dbcontext file - translator between model classes and database
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  // check this configuration on startup.cs file
        {
            // default constructor
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);


            base.OnModelCreating(modelBuilder);
        }

        // create tables
        public DbSet<ActorM> Actors { get; set; }
        public DbSet<MovieM> Movies { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<CinemaM> Cinemas { get; set; }
        public DbSet<ProducerM> Producers { get; set; }

        // Order related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItems> ShoppingCartItems { get; set; }
    }
}

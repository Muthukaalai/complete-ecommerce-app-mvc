using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<MovieM>
    {
        Task<MovieM> GetMovieByIdAsync(int id);
        Task<NewMovieDropDowns> GetNewMovieDropDownValues();
        Task AddNewMovieAsync(NewMovieM data);
        Task UpdateAddNewMovieAsync(NewMovieM data);
    }
}

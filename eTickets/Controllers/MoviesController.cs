using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
          //  var allMovies = await _context.Movies.ToListAsync(); // to get movie details
            var allMovies = await _service.GetAllAsync(n=> n.Cinema); // to get movie & Cinema details - includeProperty
            return View(allMovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains
                (searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allMovies);
        }

        // GET: Movies/details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }

        // GTE: Movies/create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinema, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actor, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropDownValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinema, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actor, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        // GTE: Movies/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                Price = movieDetails.Price,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropdownsData = await _service.GetNewMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinema, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actor, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropDownValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinema, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actor, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateAddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] ProducerM producer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(producer);
        //    }
        //    await _service.AddAsync(producer);    // add data to db
        //    return RedirectToAction(nameof(Index));
        //}
    }
}

using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller  // ActorsController is inherited from Controller - to know more click Controller f12
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()  // default action result
        {
            var data = await _service.GetAll();  // will return all actors from our db
            return View(data);
        }

        // Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}

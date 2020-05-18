using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Services;
using MovieApp.Web.Models.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var actors = await _actorService.GetActorsAsync();

            return View(actors);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateActorModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var actor = await _actorService.CreateActorAsync(model.Name, model.Born);

            return RedirectToAction(nameof(Index));
        }
    }
}

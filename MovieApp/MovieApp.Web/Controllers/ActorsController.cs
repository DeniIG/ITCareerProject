using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Data.Models;
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
        private readonly MovieDbContext _context;


        public ActorsController(IActorService actorService, MovieDbContext context)
        {
            _actorService = actorService;
            _context = context;
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

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await this._actorService.GetActorAsync(id);
            return View(actor);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit (Actor actor)
        {
            if(ModelState.IsValid)
            {
                await this._actorService.EditActorAsync(actor);
                return RedirectToAction(nameof(Index));
            }

            return View(actor);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await this._actorService.GetActorAsync(id);
            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this._actorService.DeleteActorAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

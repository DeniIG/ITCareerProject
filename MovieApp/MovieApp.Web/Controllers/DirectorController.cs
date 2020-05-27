using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Data.Entities;
using MovieApp.Services;
using MovieApp.Web.Models.Directors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class DirectorController : Controller
    {

        private readonly IDirectorService _directorService;
        private readonly MovieDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DirectorController(IDirectorService directorService, MovieDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _directorService = directorService;
            _context = context;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (this.User != null && this._signInManager.IsSignedIn(this.User))
            {
                var directors = await _directorService.GetDirectorsAsync();

                return View(directors);
            }

            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> Details(int id)
        {
            Director director = await this._directorService.GetDirectorAsync(id);

            return View(director);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateDirectorModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var director = await _directorService.CreateDirectorAsync(model.Name, model.Age, model.Country);

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var director = await this._directorService.GetDirectorAsync(id);
            return View(director);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Director director)
        {
            if (ModelState.IsValid)
            {
                await this._directorService.EditDirectorAsync(director);
                return RedirectToAction(nameof(Index));
            }

            return View(director);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var director = await this._directorService.GetDirectorAsync(id);
            return View(director);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this._directorService.DeleteDirectorAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

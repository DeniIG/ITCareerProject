using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Services;
using MovieApp.Web.Models.Directors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class DirectorsController : Controller
    {

        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var directors = await _directorService.GetDirectorsAsync();

            return View(directors);
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
    }
}

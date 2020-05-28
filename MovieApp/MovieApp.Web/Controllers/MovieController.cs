using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Data.Entities;
using MovieApp.Services;
using MovieApp.Web.Models.Movies;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly MovieDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public MovieController(IMovieService movieService, MovieDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _movieService = movieService;
            _context = context;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (this.User != null /* && this._signInManager.IsSignedIn(this.User) */)
            {
                var movies = await _movieService.GetMoviesAsync();

                return View(movies);
            }

            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> Details(int id)
        {
            Movie movie = await this._movieService.GetMovieAsync(id);

            return View(movie);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateMovieModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var actor = await _movieService.CreateMovieAsync(model.Title, model.ReleaseDate, model.Director, model.Genre);

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await this._movieService.GetMovieAsync(id);
            return View(movie);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await this._movieService.EditMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.DeleteMovieAsync(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this._movieService.DeleteMovieAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
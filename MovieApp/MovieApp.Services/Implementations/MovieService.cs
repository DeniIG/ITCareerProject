using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _dbContext;

        public MovieService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Movie> CreateMovieAsync(string title, DateTime releaseDate, Director director, string genre)
        {
            var movie = new Movie()
            {
                Title = title,
                ReleaseDate = releaseDate,
                Director = director,
                Genre = genre
            };

            _dbContext.Add(movie);

            await _dbContext.SaveChangesAsync();

            return movie;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);

            if (movie is null)
            {
                return false;
                throw new ArgumentException("Movie does not exist");
            }

            _dbContext.Remove(movie);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditMovieAsync(Movie model)
        {
            var movie = await _dbContext.Movies.FindAsync(model.Id);

            if (movie is null)
            {
                return false;
                throw new ArgumentException("Movie does not exist");
            }

            movie.Title = model.Title;
            movie.ReleaseDate = model.ReleaseDate;
            movie.Director = model.Director;
            movie.Genre = model.Genre;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _dbContext.Movies.FindAsync(id);
        }

        public async Task<ICollection<Movie>> GetMoviesAsync(int page = 1, int elements = 10)
        {
            return await _dbContext.Movies
                .Skip((page - 1) * elements)
                .Take(elements)
                .ToArrayAsync();
        }

        public async Task<ICollection<Movie>> SearchMoviesAsync(string term, int page = 1, int elements = 10)
        {
            return await _dbContext.Movies
                .Skip((page - 1) * elements)
                .Take(elements)
                .Select(b =>
                    new Movie()
                    {
                        Id = b.Id,
                        Title = b.Title
                    })
                .ToArrayAsync();
        }
    }
}

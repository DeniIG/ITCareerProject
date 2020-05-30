using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Services
{
    public interface IMovieService
    {
        Task<Movie> CreateMovieAsync(string title, DateTime releaseDate, string director, string genre);

        Task<bool> DeleteMovieAsync(int id);

        Task<bool> EditMovieAsync(Movie model);

        Task<Movie> GetMovieAsync(int id);

        Task<ICollection<Movie>> GetMoviesAsync(int page = 1, int elements = 10);

        Task<ICollection<Movie>> SearchMoviesAsync(string term, int page = 1, int elements = 10);
    }
}

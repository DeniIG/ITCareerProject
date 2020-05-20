using MovieApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services
{
    public interface IDirectorService
    {
        Task<Director> CreateDirectorAsync(string name, int age, string country);
        
        Task<bool> DeleteDirectorAsync(int id);

        Task<bool> EditDirectorAsync(Director model);

        Task<Director> GetDirectorAsync(int id);

        Task<ICollection<Director>> GetDirectorsAsync(int page = 1, int elements = 10);

        Task<ICollection<Director>> SearchDirectorsAsync(string term, int page = 1, int elements = 10);
    }
}

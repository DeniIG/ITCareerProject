using MovieApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services
{
    public interface IActorService
    {
        Task<Actor> CreateActorAsync(string name, DateTime born);

        Task<bool> DeleteActorAsync(int id);

        Task<bool> EditActorAsync(Actor model);

        Task<Actor> GetActorAsync(int id);

        Task<ICollection<Actor>> GetActorsAsync(int page = 1, int elements = 10);

        Task<ICollection<Actor>> SearchActorsAsync(string term, int page = 1, int elements = 10);
    }
}

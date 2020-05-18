using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementations
{
    public class ActorService : IActorService
    {
        private readonly MovieDbContext _dbContext;

        public ActorService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Actor> CreateActorAsync(string name, DateTime born)
        {
            var actor = new Actor()
            {
                Name = name,
                Born = born
            };

            _dbContext.Add(actor);

            await _dbContext.SaveChangesAsync();

            return actor;
        }

        public async Task<bool> DeleteActorAsync(int id)
        {
            var actor = await _dbContext.Actors.FindAsync(id);

            if (actor is null)
            {
                return false;
            }

            _dbContext.Remove(actor);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditActorAsync(Actor model)
        {
            var actor = await _dbContext.Actors.FindAsync(model.Id);

            if (actor is null)
            {
                return false;
            }

            actor.Name = model.Name;
            actor.Born = model.Born;
           
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Actor> GetActorAsync(int id)
        {
            return await _dbContext.Actors.FindAsync(id);
        }

        public async Task<ICollection<Actor>> GetActorsAsync(int page = 1, int elements = 10)
        {
            return await _dbContext.Actors
                 .Skip((page - 1) * elements)
                 .Take(elements)
                 .ToArrayAsync();
        }

        public async Task<ICollection<Actor>> SearchActorsAsync(string term, int page = 1, int elements = 10)
        {
            return await _dbContext.Actors
               .Skip((page - 1) * elements)
               .Take(elements)
               .Select(b =>
                   new Actor()
                   {
                       Id = b.Id,
                       Name = b.Name
                   })
               .ToArrayAsync();
        }
    }
}

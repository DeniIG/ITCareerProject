using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementations
{
    class DirectorService : IDirectorService
    {
        private readonly MovieDbContext _dbContext;

        public DirectorService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Director> CreateDirectorAsync(string name, int age, string country)
        {
            var director = new Director()
            {
                Name = name,
                Age = age,
                Country = country
            };

            _dbContext.Add(director);

            await _dbContext.SaveChangesAsync();

            return director;
        }

        public async Task<bool> DeleteDirectorAsync(int id)
        {
            var director = await _dbContext.Directors.FindAsync(id);

            if (director is null)
            {
                return false;
                throw new ArgumentException("Director does not exist");
            }

            _dbContext.Remove(director);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditDirectorAsync(Director model)
        {
            var director = await _dbContext.Directors.FindAsync(model.Id);

            if(director is null)
            {
                return false;
                throw new ArgumentException("Director does not exist");
            }

            director.Name = model.Name;
            director.Age = model.Age;
            director.Country = model.Country;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Director> GetDirectorAsync(int id)
        {
            return await _dbContext.Directors.FindAsync(id);
        }

        public async Task<ICollection<Director>> GetDirectorsAsync(int page = 1, int elements = 10)
        {
            return await _dbContext.Directors
                 .Skip((page - 1) * elements)
                 .Take(elements)
                 .ToArrayAsync();
        }

        public async Task<ICollection<Director>> SearchDirectorsAsync(string term, int page = 1, int elements = 10)
        {
            return await _dbContext.Directors
               .Skip((page - 1) * elements)
               .Take(elements)
               .Select(b =>
                   new Director()
                   {
                       Id = b.Id,
                       Name = b.Name
                   })
               .ToArrayAsync();
        }
    }
}

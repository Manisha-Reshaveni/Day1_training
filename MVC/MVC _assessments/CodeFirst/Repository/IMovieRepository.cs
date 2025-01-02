using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Repository
{
    interface IMovieRepository
    {

        void Create(Movie movie);
        void Edit(Movie movie);
        Movie GetById(int id);
        IEnumerable<Movie> GetAllMoviesByYear(int year);

        IEnumerable<Movie> GetAllMovies();
    }
}

using MovieFinder.Domain.AggregateModels.MovieAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Application.Interfaces.Repositories
{
    public interface IMovieGenreRepository : IGenericRepository<MovieGenre>
    {
    }
}

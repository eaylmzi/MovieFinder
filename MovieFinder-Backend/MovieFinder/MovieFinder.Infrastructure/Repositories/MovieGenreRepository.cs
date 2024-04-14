using MongoDB.Driver;
using MovieFinder.Application.Interfaces.Repositories;
using MovieFinder.Domain.AggregateModels.MovieAggregate;
using MovieFinder.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Infrastructure.Repositories
{
    public class MovieGenreRepository : GenericRepository<MovieGenre>, IMovieGenreRepository
    {
        public MovieGenreRepository(IMovieFinderDatabaseSettings settings, IMongoClient mongoClient) : base(settings, mongoClient)
        {
        }
    }
}

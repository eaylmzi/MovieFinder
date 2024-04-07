using AutoMapper;
using DnsClient;
using MediatR;
using MovieFinder.Application.Features.Queries.ViewModels;
using MovieFinder.Application.Interfaces.Repositories;
using MovieFinder.Domain.AggregateModels.MovieAggregate;
using MovieFinder.Domain.Enums;
using MovieFinder.Domain.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Application.Features.Queries.GetMovieDetailByName
{
    public class GetMoviesDetailsQueryHandler : IRequestHandler<GetMoviesDetailsQuery, Response<List<MovieDetailViewModel>>>
    {
        IMovieRepository movieRepository;
        ICastRepository castRepository;
        private readonly IMapper mapper;

        public GetMoviesDetailsQueryHandler(IMovieRepository movieRepository, IMapper mapper, ICastRepository castRepository)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
            this.castRepository = castRepository;
        }
        /// <summary>
        /// Handles the movie query and retrieves movie details asynchronously.
        /// </summary>
        /// <param name="request">The movie query request.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with movie details.</returns>
        public async Task<Response<List<MovieDetailViewModel>>> Handle(GetMoviesDetailsQuery request, CancellationToken cancellationToken)
        {
            // Determine the search type based on the request
            var searchType = SearchType.FromName(request.SearchType);

            // Get movies based on the specified search type asynchronously
            List<Movie> movieList = await GetMoviesAsync(request, searchType);

            // If no movies are retrieved, or the list is empty, return a failure response
            if (movieList == null || movieList.Count == 0)
            {
                return Response<List<MovieDetailViewModel>>.CreateFailureMessage(Error.MOVIE_LIST_NOT_RETRIEVED);
            }

            // Map Movie objects to MovieDetailViewModel objects using AutoMapper
            var movieDetailList = movieList.Select(movie => mapper.Map<MovieDetailViewModel>(movie)).ToList();

            // Return a success response with the list of movie details
            return Response<List<MovieDetailViewModel>>.CreateSuccessMessage(movieDetailList, Success.MOVIE_LIST_SUCCESSFULLY_RETRIEVED);
        }

        /// <summary>
        /// Retrieves movies asynchronously based on the specified query and search type.
        /// </summary>
        /// <param name="request">The movie query request.</param>
        /// <param name="searchType">The type of search (e.g., by movie name, director name, star name, year).</param>
        /// <returns>A task representing the asynchronous operation, containing a list of Movie objects.</returns>
        private async Task<List<Movie>> GetMoviesAsync(GetMoviesDetailsQuery request, SearchType searchType)
        {
            switch (searchType.Id)
            {
                case 1:
                    return await GetMoviesByMovieNameAsync(request.Name);
                case 2:
                    return await GetMoviesByDirectorNameAsync(request.Name);
                case 3:
                    return await GetMoviesByStarNameAsync(request.Name);
                case 4:
                    return await GetMoviesByYearAsync(request.Name);
                default:
                    return await GetMoviesByMovieNameAsync(request.Name);
            }
        }

        /// <summary>
        /// Retrieves movies by star name asynchronously.
        /// </summary>
        /// <param name="name">The name of the star.</param>
        /// <returns>A task representing the asynchronous operation, containing a list of Movie objects.</returns>
        private async Task<List<Movie>> GetMoviesByStarNameAsync(string name)
        {
            // Retrieve the cast information by star name
            var cast = await castRepository.GetSingleAsync(i => i.Name == name && i.Title.Contains(TitleType.Star.ToString()));

            // Retrieve movies associated with the star
            var movies = await movieRepository.GetAsync(i => i.StarsId.Contains(cast.Id));

            return movies;
        }

        /// <summary>
        /// Retrieves movies by director name asynchronously.
        /// </summary>
        /// <param name="name">The name of the director.</param>
        /// <returns>A task representing the asynchronous operation, containing a list of Movie objects.</returns>
        private async Task<List<Movie>> GetMoviesByDirectorNameAsync(string name)
        {
            // Retrieve the cast information by director name
            var cast = await castRepository.GetSingleAsync(i => i.Name == name && i.Title.Contains(TitleType.Director.ToString()));

            // Retrieve movies directed by the director
            var movies = await movieRepository.GetAsync(i => i.DirectorId.Contains(cast.Id));

            return movies;
        }

        /// <summary>
        /// Retrieves movies by movie name asynchronously.
        /// </summary>
        /// <param name="name">The name of the movie.</param>
        /// <returns>A task representing the asynchronous operation, containing a list of Movie objects.</returns>
        private async Task<List<Movie>> GetMoviesByMovieNameAsync(string name)
        {
            // Retrieve movies by movie name
            var movies = await movieRepository.GetAsync(i => i.Name == name);

            return movies;
        }

        /// <summary>
        /// Retrieves movies by release year asynchronously.
        /// </summary>
        /// <param name="year">The release year of the movie.</param>
        /// <returns>A task representing the asynchronous operation, containing a list of Movie objects.</returns>
        private async Task<List<Movie>> GetMoviesByYearAsync(string year)
        {
            // Convert the year to integer
            var releaseYear = int.Parse(year);

            // Retrieve movies by release year
            var movies = await movieRepository.GetAsync(i => i.Year == releaseYear);

            return movies;
        }

    }
}

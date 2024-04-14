using AutoMapper;
using MediatR;
using MovieFinder.Application.Dtos;
using MovieFinder.Application.Features.Queries.GetMovieDetailByName;
using MovieFinder.Application.Features.Queries.ViewModels;
using MovieFinder.Application.Interfaces.Repositories;
using MovieFinder.Application.Interfaces.StringHelper;
using MovieFinder.Domain.AggregateModels.MovieAggregate;
using MovieFinder.Domain.Enums;
using MovieFinder.Domain.Message;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieFinder.Application.Features.Queries.GetAllMovies
{

    public class GetAllMoviesDetailsQueryHandler : IRequestHandler<GetAllMoviesDetailsQuery, Response<ListPaginationDto<MovieDetailViewModel>>>
    {
        private readonly IMovieRepository movieRepository;
        private readonly IMovieGenreRepository movieGenreRepository;
        private readonly ICastRepository castRepository;
        private readonly ITextProcessing textProcessing;
        private readonly IPaginationRepository<Movie> pagePaginationRepository;
        private readonly IMapper mapper;

       
        public GetAllMoviesDetailsQueryHandler(IMovieRepository movieRepository, IMapper mapper, ICastRepository castRepository, IMovieGenreRepository movieGenreRepository, ITextProcessing textProcessing, IPaginationRepository<Movie> pagePaginationRepository)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
            this.castRepository = castRepository;
            this.movieGenreRepository = movieGenreRepository;
            this.textProcessing = textProcessing;
            this.pagePaginationRepository = pagePaginationRepository;
        }

        /// <summary>
        /// Handles the retrieval of detailed movie information asynchronously.
        /// </summary>
        /// <param name="request">The request containing pagination information.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A response containing paginated movie details.</returns>
        public async Task<Response<ListPaginationDto<MovieDetailViewModel>>> Handle(GetAllMoviesDetailsQuery request, CancellationToken cancellationToken)
        {
            // Get movies asynchronously with pagination
            Expression<Func<Movie, bool>> filter = i => i == i;
            ListPaginationDto<Movie> movieList = await pagePaginationRepository.GetItemsWithPagination(filter, request.paginationDto.Page, request.paginationDto.PageResult);

            // If no movies are retrieved or the list is empty, return a failure response
            if (movieList.Items == null || movieList.Items.Count == 0)
            {
                return Response<ListPaginationDto<MovieDetailViewModel>>.CreateFailureMessage(Error.MOVIE_LIST_NOT_RETRIEVED);
            }

            // Process each movie asynchronously
            foreach (Movie movie in movieList.Items)
            {
                movie.Name = textProcessing.FirstLetterTurnUpper(movie.Name);
                await ProcessDirector(movie);
                await ProcessStars(movie);
                await ProcessWriters(movie);
                await ProcessGenres(movie);
            }

            // Map Movie objects to MovieDetailViewModel objects using AutoMapper
            var movieDetailList = movieList.Items.Select(movie => mapper.Map<MovieDetailViewModel>(movie)).ToList();

            // Return a success response with the list of movie details
            return Response<ListPaginationDto<MovieDetailViewModel>>.CreateSuccessMessage(new ListPaginationDto<MovieDetailViewModel>
            {
                Items = movieDetailList,
                CurrentPage = movieList.CurrentPage,
                PageCount = movieList.PageCount,
                TotalItem = movieList.TotalItem
            }, Success.MOVIE_LIST_SUCCESSFULLY_RETRIEVED);
        }

        /// <summary>
        /// Processes the director name for a movie.
        /// </summary>
        /// <param name="movie">The movie for which to process the director.</param>
        private async Task ProcessDirector(Movie movie)
        {
            Cast director = await castRepository.GetByIdAsync(movie.DirectorId);
            movie.DirectorId = textProcessing.FirstLetterTurnUpper(director.Name) ?? "Unknown Director";
        }

        /// <summary>
        /// Processes the star name for a movie.
        /// </summary>
        /// <param name="movie">The movie for which to process the stars.</param>
        private async Task ProcessStars(Movie movie)
        {
            List<string> starNames = new List<string>();
            foreach (string starId in movie.StarsId)
            {
                Cast star = await castRepository.GetByIdAsync(starId);
                starNames.Add(textProcessing.FirstLetterTurnUpper(star.Name) ?? "Unknown Star");
            }
            movie.StarsId = starNames;
        }

        /// <summary>
        /// Processes the writer name for a movie.
        /// </summary>
        /// <param name="movie">The movie for which to process the writers.</param>
        private async Task ProcessWriters(Movie movie)
        {
            List<string> writerNames = new List<string>();
            foreach (string writerId in movie.WritersId)
            {
                Cast writer = await castRepository.GetByIdAsync(writerId);
                writerNames.Add(textProcessing.FirstLetterTurnUpper(writer.Name) ?? "Unknown Writer");
            }
            movie.WritersId = writerNames;
        }

        /// <summary>
        /// Processes the genre name for a movie.
        /// </summary>
        /// <param name="movie">The movie for which to process the genres.</param>
        private async Task ProcessGenres(Movie movie)
        {
            List<string> genreNames = new List<string>();
            foreach (string genreId in movie.MovieTypesId)
            {
                MovieGenre movieGenre = await movieGenreRepository.GetByIdAsync(genreId);
                genreNames.Add(textProcessing.FirstLetterTurnUpper(movieGenre.Name) ?? "Unknown Genre");
            }
            movie.MovieTypesId = genreNames;
        }
    }
}

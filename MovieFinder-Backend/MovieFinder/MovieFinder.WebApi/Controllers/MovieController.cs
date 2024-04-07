using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MovieFinder.Application.Dtos;
using MovieFinder.Application.Features.Queries.GetMovieDetailByName;
using MovieFinder.Application.Features.Queries.ViewModels;
using MovieFinder.Application.Interfaces.Repositories;
using MovieFinder.Domain.AggregateModels.MovieAggregate;

namespace MovieFinder.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMediator _mediator;
        public MovieController(IMovieRepository movieRepository, IMediator mediator)
        {
            _movieRepository = movieRepository;
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> GetMovie([FromBody] MovieSearchDto request)
        {
            var res = await _mediator.Send(new GetMoviesDetailsQuery(request.Name, request.SearchType));
            return Ok(res);
        }
    }
}

using MediatR;
using MovieFinder.Application.Features.Queries.ViewModels;
using MovieFinder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Application.Features.Queries.GetMovieDetailByName
{
    public class GetMoviesDetailsQuery : IRequest<Response<List<MovieDetailViewModel>>>
    {
        public string Name { get; set; } = null!;
        public string SearchType { get; set; }

        public GetMoviesDetailsQuery(string name, string searchType)
        {
            Name = name;
            SearchType = searchType;
        }
    }
}

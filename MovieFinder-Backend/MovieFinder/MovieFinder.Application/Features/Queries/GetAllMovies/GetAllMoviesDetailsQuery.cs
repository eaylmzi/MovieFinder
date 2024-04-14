using MediatR;
using MovieFinder.Application.Dtos;
using MovieFinder.Application.Features.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Application.Features.Queries.GetAllMovies
{
    public class GetAllMoviesDetailsQuery : IRequest<Response<ListPaginationDto<MovieDetailViewModel>>>
    {
        public PaginationDto paginationDto { get; set; } = null!;
        public GetAllMoviesDetailsQuery(PaginationDto paginationDto)
        {
            this.paginationDto = paginationDto;
        }
    }
}

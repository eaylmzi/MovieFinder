using AutoMapper;
using MovieFinder.Application.Features.Queries.ViewModels;
using MovieFinder.Domain.AggregateModels.MovieAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Application.Mapping.MovieMapping
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDetailViewModel>()
                    .ReverseMap();
        }
    }
}

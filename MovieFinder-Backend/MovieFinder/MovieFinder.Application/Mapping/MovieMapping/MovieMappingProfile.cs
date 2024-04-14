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
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.DirectorId))
                .ForMember(dest => dest.StarsName, opt => opt.MapFrom(src => src.StarsId))
                .ForMember(dest => dest.WritersName, opt => opt.MapFrom(src => src.WritersId))
                .ForMember(dest => dest.MovieTypesName, opt => opt.MapFrom(src => src.MovieTypesId))
                .ReverseMap();
        }
    }
}

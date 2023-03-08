using AutoMapper;
using Core.Dtos;
using Core.Entities;
using System.Drawing;

namespace Core.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Genre, GenreDto>().ReverseMap();

            CreateMap<Movie, MovieDto>()
                .ForMember(x => x.Genres, opt => opt.MapFrom(x => x.Genres.Select(i => i.Genre)));

            CreateMap<MovieDto, Movie>();
        }
    }
}

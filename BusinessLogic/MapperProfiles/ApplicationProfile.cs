using AutoMapper;
using BusinessLogic.Dtos;
using DataAccess.Entities;
using System.Drawing;

namespace BusinessLogic.MapperProfiles
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

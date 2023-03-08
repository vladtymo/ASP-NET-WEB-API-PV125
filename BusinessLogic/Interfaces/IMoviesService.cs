using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieDto>> GetAll();
        Task<MovieDto?> GetById(int id);
        Task Create(MovieDto movie);
        Task Edit(MovieDto movie);
        Task Delete(int id);
    }
}

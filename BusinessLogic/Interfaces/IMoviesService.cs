using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMoviesService
    {
        Task GetAll();
        Task<Movie?> GetById(int id);
        Task Create(Movie movie);
        Task Edit(Movie movie);
        Task Delete(int id);
    }
}

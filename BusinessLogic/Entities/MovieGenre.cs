using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class MovieGenre
    {
        // composite primary key: MovieId + GenreId
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        public Movie? Movie { get; set; }
        public Genre? Genre { get; set; }
    }
}

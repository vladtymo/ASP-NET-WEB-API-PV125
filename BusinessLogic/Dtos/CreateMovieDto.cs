using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public TimeSpan Duration { get; set; }
        public string CoverUrl { get; set; }
        public IEnumerable<int>? GenreIds { get; set; }
    }
}

using Ardalis.Specification;
using DataAccess.Entities;

namespace BusinessLogic.Specifications
{
    public static class Movies
    {
        public class OrderedAll : Specification<Movie>
        {
            public OrderedAll()
            {
                Query
                    .OrderBy(x => x.Name)
                    .Include(x => x.Genres).ThenInclude(x => x.Genre);
            }
        }
        public class ById : Specification<Movie>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Genres).ThenInclude(x => x.Genre);
            }
        }
    }   
}

namespace Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public ICollection<MovieGenre>? Genres { get; set; }
    }
}

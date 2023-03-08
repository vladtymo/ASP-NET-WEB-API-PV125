namespace Core.Entities
{
    public enum Genres : int
    {
        Sci_fi = 1,
        Adventure,
        Romance,
        Drama,
        Fantasy,
        Action,
        Anime,
        History,
        Biography,
        Comedy
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieGenre>? Movies { get; set; }
    }
}

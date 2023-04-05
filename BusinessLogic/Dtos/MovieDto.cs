namespace Core.Dtos
{
    // Data Transfer Object (DTO) - should contains data only
    // without any business logic or database specific logic
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public TimeSpan Duration { get; set; }
        public string CoverUrl { get; set; }
        public IEnumerable<GenreDto>? Genres { get; set; }
    }
}

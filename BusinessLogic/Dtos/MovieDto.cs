namespace Core.Dtos
{
    // Data Transfer Object (DTO) - should contains data only
    // without any business logic or database specific logic
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public IEnumerable<GenreDto>? Genres { get; set; }
    }
}

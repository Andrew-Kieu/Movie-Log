namespace cSharpTest.movies
{
    public record MovieRequest
    {
        public Guid Id { get; init; }
        public string Director { get; init; }
        public double Length { get; init; }
        public string Title { get; init; }  // Corrected property name
    }
}

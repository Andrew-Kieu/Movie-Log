namespace cSharpTest.Models; 

public class Movie
{
    public Guid Id { get; set; }
    public string Director { get; set; }
    public double Length { get; set; }
    public string Title { get; set; }

    public Movie()
    {
        // Parameterless constructor
    }

    public Movie(Guid id, string director, double length)
    {
        Id = id;
        Director = director;
        Length = length;
        
    }
}
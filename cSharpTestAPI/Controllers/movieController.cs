using cSharpTest.movies;
using Microsoft.AspNetCore.Mvc;
using cSharpTest.Models;

namespace cSharpTestAPI.controllers;

[ApiController]
public class movieController : ControllerBase
{
    private readonly MovieContext _context;

    
    public movieController(MovieContext context)
    {
        _context = context;
    }

    [HttpPost("/movies")]
    public async Task<IActionResult> CreateMovie(MovieRequest movieRequest)
    {
        // Assuming MovieRequest is a DTO containing data from the request
        var movie = new Movie
        {
            // Map data from the request to the Movie entity
            Director = movieRequest.Director,
            Length = movieRequest.Length,
            Title = movieRequest.Title
        };

        // Add the movie to the context and save changes to the database
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        // Return the newly created movie with its ID
        return Ok(movie);
    }

    // [HttpDelete("{id:guid}")]
    //     public async Task<IActionResult> DeleteMovie(Guid id)
    //     {
    //         var movie = await _context.Movies.FindAsync(id);
    //         if (movie == null)
    //         {
    //             return NotFound(new { message = "Movie not found." });
    //         }

    //         _context.Movies.Remove(movie);
    //         await _context.SaveChangesAsync();

    //         return NoContent();
    //     }

    

    [HttpGet("/movies")]
    public IActionResult GetAllMovies()
    {
        // Query the database to retrieve all movies
        var movies = _context.Movies.ToList();

        // Check if any movies were found
        if (movies == null || movies.Count == 0)
        {
            // Return a 404 Not Found response if no movies were found
            return NotFound("No movies found.");
        }

        // Return the list of movies as the response
        return Ok(movies);
    }

    [HttpGet("/movies/{id:guid}")]
    public IActionResult GetMovie(Guid id )
    {
        return Ok(id);
    }

   [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateMovie(Guid id, MovieRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest(new { message = "The ID in the URL does not match the ID in the request body." });
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound(new { message = "Movie not found." });
            }

            movie.Director = request.Director;
            movie.Length = request.Length;
            movie.Title = request.Title;  // Corrected property name

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return Ok(movie);
        }
    

}
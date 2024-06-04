using cSharpTestAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cSharpTest.Models;

public class MovieContext: IdentityDbContext<AppUser>
{
    public DbSet<Movie> Movies {get; set;}
    public MovieContext(DbContextOptions<MovieContext> options): base(options)
    {

    } 
     
}
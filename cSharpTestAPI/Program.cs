using cSharpTest.Models;
using cSharpTestAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");


builder.Services.AddControllers();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder();


builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseMySQL(connectionString);
});

builder.Services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<MovieContext>().AddApiEndpoints(); 



builder.Services.AddCors(options => {
    options.AddPolicy("reactApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173") ;
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();       
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

app.MapIdentityApi<AppUser>(); 

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors("reactApp");

app.Run();


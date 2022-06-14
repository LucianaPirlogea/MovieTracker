using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.Repositories.ActorRepository;
using MovieTracker.Repositories.MovieRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MovieTrackerContext>(x => x.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IActorRepository, ActorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

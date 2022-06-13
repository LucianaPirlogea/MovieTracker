﻿using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.Entities;
using MovieTracker.Models.DTOs;
using MovieTracker.Repositories.GenericRepository;
using System.Linq;

namespace MovieTracker.Repositories.MovieRepository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieTrackerContext context) : base(context) { }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await GetAll().ToListAsync();
        }
        public async Task<Movie> GetMovieByName(string name)
        {
            return await _context.Movies.Where(a => a.Title.Equals(name)).FirstOrDefaultAsync();
        }

        public List<Movie> GetMoviesByCategory(string genre)
        {
            var movies = (from a in _context.Movies
                                join b in _context.CategoryOfMovies on a.Id equals b.IdMovie
                                join c in _context.Categories on b.IdCategory equals c.Id
                                where c.Name == genre
                                select new
                                {
                                    a.Id,
                                    a.Title,
                                    a.ReleaseDate,
                                    a.Description,
                                    a.Duration,
                                    a.Poster
                                });
            var moviesToReturn = new List<Movie>();
            foreach (var movie in movies)
            {
                Movie newMovie = new Movie();
                newMovie.Id = movie.Id;
                newMovie.Title = movie.Title;
                newMovie.ReleaseDate = movie.ReleaseDate;
                newMovie.Description = movie.Description;
                newMovie.Duration = movie.Duration;
                newMovie.Poster = movie.Poster;
                moviesToReturn.Add(newMovie);
            }
            return moviesToReturn;
        }

        public List<Movie> GetMoviesByActor(string actor)
        {
            var movies = (from a in _context.Movies
                          join b in _context.Casts on a.Id equals b.IdMovie
                          join c in _context.Actors on b.IdActor equals c.Id
                          where c.Name == actor
                          select new
                          {
                              a.Id,
                              a.Title,
                              a.ReleaseDate,
                              a.Description,
                              a.Duration,
                              a.Poster
                          });
            var moviesToReturn = new List<Movie>();
            foreach (var movie in movies)
            {
                Movie newMovie = new Movie();
                newMovie.Id = movie.Id;
                newMovie.Title = movie.Title;
                newMovie.ReleaseDate = movie.ReleaseDate;
                newMovie.Description = movie.Description;
                newMovie.Duration = movie.Duration;
                newMovie.Poster = movie.Poster;
                moviesToReturn.Add(newMovie);
            }
            return moviesToReturn;
        }

    }
}

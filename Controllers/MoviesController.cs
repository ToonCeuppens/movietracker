using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using MovieTrackerAPI.Models;  // Add this to reference the Movie model.
using MovieTrackerAPI.Data;    // Add this to reference the MovieContext.

namespace MovieTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }
    [HttpGet]
public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
{
    return await _context.Movies.ToListAsync();
}

[HttpGet("{id}")]
public async Task<ActionResult<Movie>> GetMovie(int id)
{
    var movie = await _context.Movies.FindAsync(id);
    if (movie == null)
    {
        return NotFound();
    }
    return movie;
}

[HttpPost]
public async Task<ActionResult<Movie>> PostMovie(Movie movie)
{
    _context.Movies.Add(movie);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
}

[HttpPut("{id}")]
public async Task<IActionResult> PutMovie(int id, Movie movie)
{
    if (id != movie.Id)
    {
        return BadRequest();
    }
    _context.Entry(movie).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return NoContent();
}

[HttpDelete("{id}")]
public async Task<IActionResult> DeleteMovie(int id)
{
    var movie = await _context.Movies.FindAsync(id);
    if (movie == null)
    {
        return NotFound();
    }
    _context.Movies.Remove(movie);
    await _context.SaveChangesAsync();
    return NoContent();
}



    // Add CRUD endpoints here, e.g., GET, POST, PUT, DELETE
}}
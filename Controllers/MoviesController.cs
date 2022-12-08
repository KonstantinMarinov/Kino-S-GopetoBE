using KinoSGopeto.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinoSGopeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesContext _dbContext;

        public MoviesController(MoviesContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = await _dbContext.Movies.ToListAsync();

            return movies;
        }

        [HttpPost]
        public async Task<ActionResult> PostMovie(Movie movie)
        {

            await _dbContext.Movies.AddAsync(movie);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMovie(Guid id)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}

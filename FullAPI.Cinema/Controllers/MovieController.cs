using FullAPI.Cinema.Data;
using FullAPI.Cinema.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullAPI.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieController> _logger;

        public MovieController(CinemaDbContext dbContext, Mapper mapper, ILogger<MovieController> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Movie? movie = _dbContext.Movies
                    .Include(m => m.Technologies)
                    .Include(m => m.Limitation)
                    .Include(m => m.Shows)
                    .ThenInclude(s => s.MovieRoom)
                    .SingleOrDefault(m => m.MovieId == id);

                if (movie == null) 
                    return BadRequest("Movie not found");

                MovieModel model = _mapper.MapEntityToModel(movie);

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Movie> movies = _dbContext.Movies
                    .Include(m => m.Technologies)
                    .Include(m => m.Limitation)
                    .ToList();

                if (movies == null)
                    return BadRequest("Movie not found");

                List<MovieModel> models = movies.ConvertAll(_mapper.MapEntityToModel);

                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

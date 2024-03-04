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
                    .Where(m => !m.IsDeleted)
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

        [HttpPost]
        public IActionResult Post(MovieModel model)
        {
            try
            {
                var entity = _mapper.MapModelToEntity(model);
                if (model.Techonlogies != null)
                    entity.Technologies = _dbContext.Technologies.ToList()
                        .Join(model.Techonlogies, t => t.TechnologyId, mt => mt.Id, (t, mt) => t)
                        .Where(t => !t.IsDeleted)
                        .ToList();
                _dbContext.Add(entity);
                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(MovieModel model)
        {
            try
            {
                Movie? entity = _dbContext.Movies.Include(m => m.Technologies).SingleOrDefault(m => m.MovieId == model.Id);
                
                if (entity == null)
                    return BadRequest("Movie not found");

                entity.ImdbId = model.ImdbId;
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Duration = model.Duration;
                entity.LimitationId = model.LimitationId;
                if (model.Techonlogies != null)
                {
                    entity.Technologies?.RemoveAll(t => true);
                    _dbContext.SaveChanges();

                    entity.Technologies = _dbContext.Technologies.ToList()
                        .Join(model.Techonlogies, t => t.TechnologyId, mt => mt.Id, (t, mt) => t)
                        .Where(t => !t.IsDeleted)
                        .ToList();
                }

                _dbContext.Update(entity);
                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{id}/{toDelete}")]
        public IActionResult Delete(int id, bool toDelete)
        {
            try
            {
                Movie? movie = _dbContext.Movies.Include(m => m.Shows).SingleOrDefault(m => m.MovieId == id);

                if (movie == null)
                    return BadRequest("Movie not found");

                movie.IsDeleted = toDelete;
                movie.Shows?.ForEach(p => p.IsDeleted = toDelete);

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Movie not deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

using FullAPI.Cinema.Data;
using FullAPI.Cinema.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullAPI.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<TechnologyController> _logger;

        public TechnologyController(CinemaDbContext dbContext, Mapper mapper, ILogger<TechnologyController> logger)
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
                var technology = _dbContext.Technologies
                    .Include(t => t.MovieRooms)
                    .Include(t => t.Movies)
                    .SingleOrDefault(t => t.TechnologyId == id);

                if (technology == null)
                    return BadRequest("Technology not found");

                return Ok(_mapper.MapEntityToModel(technology));
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
                var technologies = _dbContext.Technologies.ToList();

                return Ok(technologies.ConvertAll(_mapper.MapEntityToItemModel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(TechnologyModel model)
        {
            try
            {
                _dbContext.Add(_mapper.MapModelToEntity(model));
                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Technology not created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(TechnologyModel model)
        {
            try
            {
                Technology? technology = _dbContext.Technologies.SingleOrDefault(t => t.TechnologyId == model.Id);

                if (technology == null)
                    return BadRequest("Technology not found");

                technology.Name = model.Name;
                technology.TechnologyType = model.TechnologyType;

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Technology not edited");
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
                Technology? technology = _dbContext.Technologies.SingleOrDefault(t => t.TechnologyId == id);

                if (technology == null)
                    return BadRequest("Technology not found");

                technology.IsDeleted = toDelete;

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Technology not deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

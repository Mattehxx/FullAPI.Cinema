using FullAPI.Cinema.Data;
using FullAPI.Cinema.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullAPI.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitationController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<LimitationController> _logger;

        public LimitationController(CinemaDbContext dbContext, Mapper mapper, ILogger<LimitationController> logger)
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
                var limitation = _dbContext.Limitations
                    .Include(l => l.Movies)
                    .SingleOrDefault(l => l.LimitationId == id);

                if (limitation == null)
                    return BadRequest("Limitation not found");

                return Ok(_mapper.MapEntityToModel(limitation));
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
                var limitations = _dbContext.Limitations.ToList();

                return Ok(limitations.ConvertAll(_mapper.MapEntityToModel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(LimitationModel model)
        {
            try
            {
                _dbContext.Add(_mapper.MapModelToEntity(model));
                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Limitation not created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(LimitationModel model)
        {
            try
            {
                Limitation? limitation = _dbContext.Limitations.SingleOrDefault(l => l.LimitationId == model.Id);

                if (limitation == null)
                    return BadRequest("Limitation not found");

                limitation.Name = model.Name;
                limitation.Description = model.Description;

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Limitation not edited");
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
                Limitation? limitation = _dbContext.Limitations.SingleOrDefault(l => l.LimitationId == id);

                if (limitation == null)
                    return BadRequest("Limitation not found");

                limitation.IsDeleted = toDelete;

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Limitation not deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

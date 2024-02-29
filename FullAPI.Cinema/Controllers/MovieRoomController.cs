using FullAPI.Cinema.Data;
using FullAPI.Cinema.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FullAPI.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieRoomController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieRoomController> _logger;

        public MovieRoomController(CinemaDbContext dbContext, Mapper mapper, ILogger<MovieRoomController> logger)
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
                var movieRoom = _dbContext.MovieRooms
                    .Include(m => m.Shows)
                    .Include(m => m.Technologies)
                    .SingleOrDefault(m => m.MovieRoomId == id);

                if (movieRoom == null)
                    return BadRequest("Movie room not found");

                return Ok(_mapper.MapEntityToModel(movieRoom));
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
                var movieRooms = _dbContext.MovieRooms
                    .Include(s => s.Technologies)
                    .ToList();

                return Ok(movieRooms.ConvertAll(_mapper.MapEntityToModel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(MovieRoomModel model)
        {
            try
            {
                model.Id = 0;

                _dbContext.Add(_mapper.MapModelToEntity(model));
                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Movie room not created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(MovieRoomModel model)
        {
            try
            {
                MovieRoom? movieRoom = _dbContext.MovieRooms.SingleOrDefault(m => m.MovieRoomId == model.Id);

                if (movieRoom == null)
                    return BadRequest("Show not found");

                movieRoom.Name = model.Name;
                movieRoom.CleanTimeMins = model.CleanTimeMins;

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Movie room not edited");
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
                MovieRoom? movieRoom = _dbContext.MovieRooms.SingleOrDefault(m => m.MovieRoomId == id);

                if (movieRoom == null)
                    return BadRequest("Show not found");

                movieRoom.IsDeleted = toDelete;

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Show not deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        #region Utility

        private List<Show>? DateInBound(ShowModel model)
        {
            try
            {
                List<Show> sameTimeShows = _dbContext.Shows
                    .Where(s => 
                    s.ShowId != model.Id &&
                    s.MovieRoomId == model.MovieRoomId &&
                    ((model.StartTime > s.StartTime && model.StartTime < s.EndTime) ||
                    (model.EndTime > s.StartTime && model.EndTime < s.EndTime)))
                    .ToList();

                return sameTimeShows;
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }  

        #endregion
    }
}

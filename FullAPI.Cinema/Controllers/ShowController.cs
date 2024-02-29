using FullAPI.Cinema.Data;
using FullAPI.Cinema.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullAPI.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<ShowController> _logger;

        public ShowController(CinemaDbContext dbContext, Mapper mapper, ILogger<ShowController> logger)
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
                var show = _dbContext.Shows
                    .Include(s => s.Activities).ThenInclude(a => a.Employee)
                    .Include(s => s.Activities).ThenInclude(a => a.Role)
                    .Include(s => s.MovieRoom)
                    .Include(s => s.Movie).ThenInclude(m => m.Limitation)
                    .SingleOrDefault(s => s.ShowId == id);

                if (show == null)
                    return BadRequest("Show not found");

                return Ok(_mapper.MapEntityToDetailShowModel(show));
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
                var shows = _dbContext.Shows
                    .Include(s => s.Movie)
                    .Include(s => s.MovieRoom)
                    .ToList();

                return Ok(shows.ConvertAll(_mapper.MapEntityToModel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(ShowModel model)
        {
            try
            {
                model.Id = 0;

                if (model.MovieDuration == null && model.MovieRoomCleanTime == null)
                {
                    model.MovieDuration = _dbContext.Movies
                        .Where(m => m.MovieId == model.MovieId).Select(m => m.Duration).SingleOrDefault();

                    model.MovieRoomCleanTime = _dbContext.MovieRooms
                        .Where(m => m.MovieRoomId == model.MovieRoomId).Select(m => m.CleanTimeMins).SingleOrDefault();
                }

                var entity = _mapper.MapModelToEntity(model);

                var sameTimeShows = DateInBound(entity);

                if (sameTimeShows == null || sameTimeShows.Count > 0)
                    return BadRequest("There is already another show in the specified time span");

                _dbContext.Add(entity);
                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Show not created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(ShowModel model)
        {
            try
            {
                Show? show = _dbContext.Shows.SingleOrDefault(s => s.ShowId == model.Id);

                if (show == null)
                    return BadRequest("Show not found");

                if (model.MovieDuration == null && model.MovieRoomCleanTime == null)
                {
                    model.MovieDuration = _dbContext.Movies
                        .Where(m => m.MovieId == model.MovieId).Select(m => m.Duration).SingleOrDefault();

                    model.MovieRoomCleanTime = _dbContext.MovieRooms
                        .Where(m => m.MovieRoomId == model.MovieRoomId).Select(m => m.CleanTimeMins).SingleOrDefault();
                }

                var entity = _mapper.MapModelToEntity(model);
                var sameTimeShows = DateInBound(entity);

                if (sameTimeShows == null || sameTimeShows.Count > 0)
                    return BadRequest("There is already another show in the specified time span");

                show.Price = model.Price;
                show.StartTime = model.StartTime;
                show.EndTime = model.StartTime.AddMinutes((double)(model.MovieDuration + model.MovieRoomCleanTime));
                show.MovieRoomId = model.MovieRoomId;
                show.MovieId = model.MovieId;

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Show not edited");
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
                Show? show = _dbContext.Shows.SingleOrDefault(s => s.ShowId == id);

                if (show == null)
                    return BadRequest("Show not found");

                show.IsDeleted = toDelete;

                if (toDelete)
                    _dbContext.RemoveRange(_dbContext.Activities.Where(a => a.ShowId == id).ToList());

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Show not deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        #region Utility

        private List<Show>? DateInBound(Show entity)
        {
            try
            {
                List<Show> sameTimeShows = _dbContext.Shows
                    .Where(s => 
                    s.ShowId != entity.ShowId &&
                    s.MovieRoomId == entity.MovieRoomId &&
                    ((entity.StartTime >= s.StartTime && entity.StartTime <= s.EndTime) ||
                    (entity.EndTime >= s.StartTime && entity.EndTime <= s.EndTime)))
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

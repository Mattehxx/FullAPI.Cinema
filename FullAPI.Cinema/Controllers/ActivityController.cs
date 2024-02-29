using FullAPI.Cinema.Data;
using FullAPI.Cinema.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullAPI.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<ActivityController> _logger;

        public ActivityController(CinemaDbContext dbContext, Mapper mapper, ILogger<ActivityController> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var activities = _dbContext.Activities
                    .Include(a => a.Employee)
                    .Include(a => a.Role)
                    .Include(a => a.Show).ThenInclude(s => s.MovieRoom)
                    .ToList();

                return Ok(activities.ConvertAll(_mapper.MapEntityToModel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(ActivityModel model)
        {
            try
            {
                _dbContext.Add(_mapper.MapModelToEntity(model));
                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Activity not created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(ActivityModel model)
        {
            try
            {
                Activity? activity = _dbContext.Activities.SingleOrDefault(a => a.ActivityId == model.Id);

                if (activity == null)
                    return BadRequest("Activity not found");

                activity.EmployeeId = model.EmployeeId;
                activity.RoleId = model.RoleId;
                activity.ShowId = model.ShowId;

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Activity not edited");
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
                Activity? activity = _dbContext.Activities.SingleOrDefault(a => a.ActivityId == id);

                if (activity == null)
                    return BadRequest("Activity not found");

                _dbContext.Remove(activity);

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Activity not deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

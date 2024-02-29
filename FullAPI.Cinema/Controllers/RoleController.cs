using FullAPI.Cinema.Data;
using FullAPI.Cinema.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullAPI.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<RoleController> _logger;

        public RoleController(CinemaDbContext dbContext, Mapper mapper, ILogger<RoleController> logger)
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
                var role = _dbContext.Roles
                    .Include(r => r.Activities).ThenInclude(a => a.Employee)
                    .Include(r => r.Activities).ThenInclude(a => a.Show)
                    .ThenInclude(s => s.MovieRoom)
                    .SingleOrDefault(r => r.RoleId == id);

                if (role == null)
                    return BadRequest("Employee not found");

                return Ok(_mapper.MapEntityToModel(role));
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
                var roles = _dbContext.Roles.ToList();

                return Ok(roles.ConvertAll(_mapper.MapEntityToModel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(RoleModel model)
        {
            try
            {
                _dbContext.Add(_mapper.MapModelToEntity(model));
                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Role not created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(RoleModel model)
        {
            try
            {
                Role? role = _dbContext.Roles.SingleOrDefault(r => r.RoleId == model.Id);

                if (role == null)
                    return BadRequest("Role not found");

                role.Description = model.Description;

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Role not edited");
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
                Role? role = _dbContext.Roles.Include(r => r.Activities).SingleOrDefault(r => r.RoleId == id);

                if (role == null)
                    return BadRequest("Role not found");

                role.IsDeleted = toDelete;

                //if(toDelete)
                //    _dbContext.RemoveRange(_dbContext.Activities.Where(a => a.RoleId == id).ToList());

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Employee not deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

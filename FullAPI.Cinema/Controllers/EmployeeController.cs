using FullAPI.Cinema.Data;
using FullAPI.Cinema.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullAPI.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieController> _logger;

        public EmployeeController(CinemaDbContext dbContext, Mapper mapper, ILogger<MovieController> logger)
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
                var employee = _dbContext.Employees
                    .Include(e => e.Activities).ThenInclude(a => a.Show).ThenInclude(s => s.MovieRoom)
                    .Include(e => e.Activities).ThenInclude(a => a.Role)
                    .SingleOrDefault(e => e.EmployeeId == id);

                if (employee == null)
                    return BadRequest("Employee not found");

                return Ok(_mapper.MapEntityToModel(employee));
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
                var employees = _dbContext.Employees.ToList();

                return Ok(employees.ConvertAll(_mapper.MapEntityToModel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(EmployeeModel model)
        {
            try
            {
                _dbContext.Add(_mapper.MapModelToEntity(model));
                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Employee not created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(EmployeeModel model)
        {
            try
            {
                Employee? employee = _dbContext.Employees.SingleOrDefault(e => e.EmployeeId == model.Id);

                if (employee == null)
                    return BadRequest("Employee not found");

                employee.Name = model.Name;
                employee.Surname = model.Surname;

                return _dbContext.SaveChanges() > 0 ? Ok() : BadRequest("Employee not edited");
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
                Employee? employee = _dbContext.Employees.Include(e => e.Activities).SingleOrDefault(e => e.EmployeeId == id);

                if (employee == null)
                    return BadRequest("Employee not found");

                employee.IsDeleted = toDelete;

                if (toDelete)
                {
                    _dbContext.RemoveRange(_dbContext.Activities.Where(a => a.EmployeeId == employee.EmployeeId).ToList());
                    employee.Activities = null;
                }

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

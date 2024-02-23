using FullAPI.Cinema.Data;
using FullAPI.Cinema.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            try
            {
                List<EmployeeModel> employeesModel = new();
                var employees = _dbContext.Employees.ToList();

                foreach (var employee in employees)
                {
                    employeesModel.Add(_mapper.MapEntityToModel(employee));
                }
                return Ok(employeesModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

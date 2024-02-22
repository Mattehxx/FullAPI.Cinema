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

        public EmployeeController(CinemaDbContext dbContext, Mapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<EmployeeModel> GetAll()
        {
            List<EmployeeModel> employeesModel = new();

            try
            {
                var employees = _dbContext.Employees.ToList();

                foreach (var employee in employees)
                {
                    employeesModel.Add(_mapper.MapEntityToModel(employee));
                }
                return employeesModel;
            }
            catch
            {
                return employeesModel;
            }
        }
    }
}

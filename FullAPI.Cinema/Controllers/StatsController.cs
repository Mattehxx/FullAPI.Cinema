using FullAPI.Cinema.Data;
using FullAPI.Cinema.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullAPI.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<StatsController> _logger;

        public StatsController(CinemaDbContext dbContext, Mapper mapper, ILogger<StatsController> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("ShowsNumber/{from}/{to}")]
        public IActionResult GetShowsNumber(DateTime from, DateTime to)
        {
            try
            {
                return Ok(_dbContext.Shows.Where(s => s.StartTime >= from && s.StartTime <= to).Count());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("AverageShowsByRoom/{from}/{to}")]
        public IActionResult GetAverageShowsByRoom(DateTime from, DateTime to)
        {
            try
            {
                var showNumberList = _dbContext.MovieRooms.Include(r => r.Shows)
                    .Select(r => r.Shows.Where(s => s.StartTime >= from && s.StartTime <= to).Count())
                    .ToList();
                double totalSum = 0;
                showNumberList.ForEach(showNumber => { totalSum += showNumber; });

                return Ok(Math.Round(totalSum / showNumberList.Count, 2));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

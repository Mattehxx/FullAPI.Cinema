using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class Mapper
    {
        #region Employee

        public EmployeeModel MapEntityToModel(Employee entity) 
        {
            return new EmployeeModel()
            {
                Id = entity.EmployeeId,
                Name = entity.Name,
                Surname = entity.Surname
            };
        }

        public Employee MapModelToEntity(EmployeeModel model)
        {
            return new Employee()
            {
                EmployeeId = model.Id,
                Name = model.Name,
                Surname = model.Surname,
            };
        }

        #endregion

        #region Movie

        public MovieModel MapEntityToModel(Movie entity)
        {
            return new MovieModel()
            {
                Id = entity.MovieId,
                ImdbId = entity.ImdbId,
                Title = entity.Title,
                Description = entity.Description,
                Duration = entity.Duration,
                Techonlogies = entity.Technologies?.ConvertAll(MapEntityToModel),
                Shows = entity.Shows?.ConvertAll(MapEntityToModel)
            };
        }

        #endregion

        public MovieShowModel MapEntityToModel(Show entity)
        {
            return new MovieShowModel()
            {
                Id = entity.ShowId,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                MovieRoomId = entity.MovieRoomId,
                MovieRoomName = entity.MovieRoom.Name
            };
        }

        public ItemModel MapEntityToModel (Technology entity)
        {
            return new ItemModel()
            {
                Id = entity.TechnologyId,
                Name = entity.Name,
                Description = entity.TechnologyType
            };
        }
    }
}

using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class Mapper
    {
        #region Activity

        public EmployeeActivityModel MapEntityToModel (Activity entity)
        {
            return new EmployeeActivityModel()
            {
                ActivityId = entity.ActivityId,
                RoleId = entity.RoleId,
                RoleName = entity.Role.Description,
                ShowId = entity.ShowId,
                ShowStartTime = entity.Show.StartTime,
                ShowEndTime = entity.Show.EndTime,
                ShowRoomId = entity.Show.MovieRoomId,
                ShowRoomName = entity.Show.MovieRoom.Name
            };
        }

        #endregion

        #region Employee

        public EmployeeModel MapEntityToModel(Employee entity) 
        {
            return new EmployeeModel()
            {
                Id = entity.EmployeeId,
                Name = entity.Name,
                Surname = entity.Surname,
                IsDeleted = entity.IsDeleted,
                Activities = entity.Activities?.ConvertAll(MapEntityToModel)
            };
        }

        public Employee MapModelToEntity(EmployeeModel model)
        {
            return new Employee()
            {
                EmployeeId = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                IsDeleted = model.IsDeleted
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
                IsDeleted = entity.IsDeleted,
                Techonlogies = entity.Technologies?.ConvertAll(MapEntityToModel),
                Shows = entity.Shows?.ConvertAll(MapEntityToModel)
            };
        }

        public Movie MapModelToEntity (MovieModel model)
        {
            return new Movie()
            {
                MovieId = model.Id,
                ImdbId = model.ImdbId,
                Title = model.Title,
                Description = model.Description,
                Duration = model.Duration,
                IsDeleted = model.IsDeleted,
                LimitationId = model.LimitationId
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
                IsDeleted = entity.IsDeleted,
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

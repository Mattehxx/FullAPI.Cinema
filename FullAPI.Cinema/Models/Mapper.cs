using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class Mapper
    {
        #region Activity

        public EmployeeActivityModel MapEntityToEmployeeActivityModel(Activity entity)
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

        public ShowActivityModel MapEntityToShowActivityModel(Activity entity)
        {
            return new ShowActivityModel()
            {
                ActivityId = entity.ActivityId,
                EmployeeId = entity.EmployeeId,
                EmployeeName = entity.Employee.Name,
                EmployeeSurname = entity.Employee.Surname,
                RoleId = entity.RoleId,
                RoleName = entity.Role.Description
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
                Activities = entity.Activities?.ConvertAll(MapEntityToEmployeeActivityModel)
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
                Shows = entity.Shows?.ConvertAll(MapEntityToMovieShowModel)
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

        #region Show

        public ShowModel MapEntityToModel(Show entity)
        {
            return new ShowModel()
            {
                Id = entity.ShowId,
                Price = entity.Price,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                MovieRoomId = entity.MovieRoomId,
                MovieRoomCleanTime = entity.MovieRoom.CleanTimeMins,
                MovieId = entity.MovieId,
                MovieDuration = entity.Movie.Duration,
                IsDeleted = entity.IsDeleted
            };
        }

        public Show MapModelToEntity(ShowModel model)
        {
            return new Show()
            {
                ShowId = model.Id,
                Price = model.Price,
                StartTime = model.StartTime,
                EndTime = model.StartTime.AddMinutes(model.MovieDuration + model.MovieRoomCleanTime),
                IsDeleted = model.IsDeleted,
                MovieRoomId = model.MovieRoomId,
                MovieId = model.MovieId
            };
        }

        public MovieShowModel MapEntityToMovieShowModel(Show entity)
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

        public DetailShowModel MapEntityToDetailShowModel(Show entity)
        {
            return new DetailShowModel()
            {
                Id = entity.ShowId,
                Price = entity.Price,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                MovieRoomId = entity.MovieRoomId,
                MovieRoomName = entity.MovieRoom.Name,
                MovieId = entity.MovieId,
                MovieName = entity.Movie.Title,
                LimitationId = entity.Movie.LimitationId,
                LimitationDescription = entity.Movie.Limitation?.Name,
                Activities = entity.Activities?.ConvertAll(MapEntityToShowActivityModel)
            };
        }

        #endregion

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

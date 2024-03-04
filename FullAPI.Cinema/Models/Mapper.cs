using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class Mapper
    {
        #region Activity

        public ActivityModel MapEntityToModel(Activity entity)
        {
            return new ActivityModel()
            {
                Id = entity.ActivityId,
                EmployeeId = entity.EmployeeId,
                EmployeeName = entity.Employee.Name,
                EmployeeSurname = entity.Employee.Surname,
                RoleId = entity.RoleId,
                RoleDescription = entity.Role.Description,
                ShowId = entity.ShowId,
                ShowStartTime = entity.Show.StartTime,
                ShowEndTime = entity.Show.EndTime,
                MovieRoomId = entity.Show.MovieRoomId,
                MovieRoomName = entity.Show.MovieRoom.Name
            };
        }

        public Activity MapModelToEntity(ActivityModel model)
        {
            return new Activity()
            {
                ActivityId = model.Id,
                RoleId = model.RoleId,
                ShowId = model.ShowId,
                EmployeeId = model.EmployeeId
            };
        }

        public RoleActivityModel MapEntityToRoleActivityModel(Activity entity)
        {
            return new RoleActivityModel()
            {
                Id = entity.ActivityId,
                EmployeeId = entity.EmployeeId,
                EmployeeName = entity.Employee.Name,
                EmployeeSurname = entity.Employee.Surname,
                ShowId = entity.ShowId,
                ShowStartTime = entity.Show.StartTime,
                ShowEndTime = entity.Show.EndTime,
                MovieRoomId = entity.Show.MovieRoomId,
                MovieRoomName = entity.Show.MovieRoom.Name
            };
        }

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
                LimitationId = entity.LimitationId,
                Limitation = entity.Limitation?.Name,
                Techonlogies = entity.Technologies?.ConvertAll(MapEntityToItemModel),
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

        public TechnologyMovieModel MapEntityToTechnologyMovieModel(Movie entity)
        {
            return new TechnologyMovieModel()
            {
                Id = entity.MovieId,
                ImdbId = entity.ImdbId,
                Title = entity.Title,
                Description = entity.Description,
                Duration = entity.Duration,
                IsDeleted = entity.IsDeleted,
                LimitationId = entity.LimitationId
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
                IsDeleted = entity.IsDeleted,
                Activities = entity.Activities?.ConvertAll(MapEntityToShowActivityModel)
            };
        }

        public Show MapModelToEntity(ShowModel model)
        {
            return new Show()
            {
                ShowId = model.Id,
                Price = model.Price,
                StartTime = model.StartTime,
                EndTime = model.StartTime.AddMinutes((double)(model.MovieDuration + model.MovieRoomCleanTime)),
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

        public ShowRoomModel MapEntityToShowRoomModel(Show entity)
        {
            return new ShowRoomModel()
            {
                Id = entity.ShowId,
                Price = entity.Price,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                MovieId = entity.MovieId,
                MovieDuration = entity.Movie.Duration,
                IsDeleted = entity.IsDeleted
            };
        }

        public LimitationMovieModel MapEntityToLimitationMovieModel(Movie entity)
        {
            return new LimitationMovieModel()
            {
                Id = entity.MovieId,
                ImdbId = entity.ImdbId,
                Title = entity.Title,
                Description = entity.Description,
                Duration = entity.Duration,
                IsDeleted = entity.IsDeleted
            };
        }

        #endregion

        #region MovieRoom

        public MovieRoomModel MapEntityToModel (MovieRoom entity)
        {
            return new MovieRoomModel()
            {
                Id = entity.MovieRoomId,
                Name = entity.Name,
                CleanTimeMins = entity.CleanTimeMins,
                IsDeleted = entity.IsDeleted,
                Shows = entity.Shows?.ConvertAll(MapEntityToShowRoomModel),
                Technologies = entity.Technologies?.ConvertAll(MapEntityToItemModel)
            };
        }

        public MovieRoom MapModelToEntity (MovieRoomModel model)
        {
            return new MovieRoom()
            {
                MovieRoomId = model.Id,
                Name = model.Name,
                CleanTimeMins = model.CleanTimeMins,
                IsDeleted = model.IsDeleted
            };
        }

        public TechnologyMovieRoomModel MapEntityToTechnologyMovieRoomModel(MovieRoom entity)
        {
            return new TechnologyMovieRoomModel()
            {
                Id = entity.MovieRoomId,
                Name = entity.Name,
                CleanTimeMins = entity.CleanTimeMins,
                IsDeleted = entity.IsDeleted
            };
        }

        #endregion

        #region Role

        public RoleModel MapEntityToModel(Role entity)
        {
            return new RoleModel()
            {
                Id = entity.RoleId,
                Description = entity.Description,
                IsDeleted = entity.IsDeleted,
                Activities = entity.Activities?.ConvertAll(MapEntityToRoleActivityModel)
            };
        }

        public Role MapModelToEntity(RoleModel model)
        {
            return new Role()
            {
                RoleId = model.Id,
                Description = model.Description,
                IsDeleted = model.IsDeleted
            };
        }

        #endregion

        #region Limitation

        public LimitationModel MapEntityToModel(Limitation entity)
        {
            return new LimitationModel()
            {
                Id = entity.LimitationId,
                Name = entity.Name,
                Description = entity.Description,
                IsDeleted = entity.IsDeleted,
                Movies = entity.Movies?.ConvertAll(MapEntityToLimitationMovieModel)
            };
        }

        public Limitation MapModelToEntity(LimitationModel model)
        {
            return new Limitation()
            {
                LimitationId = model.Id,
                Name = model.Name,
                Description = model.Description,
                IsDeleted = model.IsDeleted
            };
        }

        #endregion

        #region Technology

        public TechnologyModel MapEntityToModel(Technology entity)
        {
            return new TechnologyModel()
            {
                Id = entity.TechnologyId,
                Name = entity.Name,
                TechnologyType = entity.TechnologyType,
                IsDeleted = entity.IsDeleted,
                MovieRooms = entity.MovieRooms?.ConvertAll(MapEntityToTechnologyMovieRoomModel),
                Movies = entity.Movies?.ConvertAll(MapEntityToTechnologyMovieModel)
            };
        }

        public Technology MapModelToEntity(TechnologyModel model)
        {
            return new Technology()
            {
                TechnologyId = model.Id,
                Name = model.Name,
                TechnologyType = model.TechnologyType,
                IsDeleted = model.IsDeleted
            };
        }

        public ItemModel MapEntityToItemModel(Technology entity)
        {
            return new ItemModel()
            {
                Id = entity.TechnologyId,
                Name = entity.Name,
                Description = entity.TechnologyType
            };
        }

        #endregion
    }
}

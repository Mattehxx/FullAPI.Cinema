﻿using FullAPI.Cinema.Data;

namespace FullAPI.Cinema.Models
{
    public class ShowModel
    {
        public required int Id { get; set; }
        public required float Price { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required int MovieRoomId { get; set; }
        public int? MovieRoomCleanTime { get; set; }
        public required int MovieId { get; set; }
        public int? MovieDuration { get; set; }
        public required bool IsDeleted { get; set; }
        public List<ShowActivityModel>? Activities { get; set; }
    }
}

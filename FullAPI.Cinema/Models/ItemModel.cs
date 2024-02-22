﻿namespace FullAPI.Cinema.Models
{
    public class ItemModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectMovieAPI.Models
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Year { get; set; }
        public int? Runtime { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
